
using System.Net.Http.Headers;
using System.Net.Http;

namespace Chillify.FrontServices.Services;

public class MemberService : IMemberService
{
    private readonly HttpClient _http;
    private readonly ILocalStorage _localStorage;

    public MemberService(HttpClient http, ILocalStorage localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    public async Task<ServiceResponse<List<Member>>> GetMembers()
    {
        FrontTokenValidation tokenValidation = await _localStorage.TokenValidation();

        if (tokenValidation.Success == false)
        {
            return new ServiceResponse<List<Member>>()
            {
                Success = false,
                Message = "Authentication problem, please login again."
            };
        }

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenValidation.Token);

        var response = await _http.GetFromJsonAsync<ServiceResponse<List<Member>>>("api/member/get");

        if (response is null)
        {
            return new ServiceResponse<List<Member>>()
            {
                Success = false,
                Message = "Can not find any member"
            };
        } 
        else
        {
            return response;
        }
    }
}
