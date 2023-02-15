
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

    public async Task<ServiceResponse<Member>> GetMember(int id)
    {
        FrontTokenValidation tokenValidation = await _localStorage.TokenValidation();

        if (tokenValidation.Success == false)
        {
            return new ServiceResponse<Member>()
            {
                Success = false,
                Message = "Authentication problem, please login again."
            };
        }

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://localhost:7089/api/member/get/{id}")
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenValidation.Token);

        using HttpResponseMessage response = await _http.SendAsync(request);

        if (response is null || response.IsSuccessStatusCode == false)
        {
            return new ServiceResponse<Member>()
            {
                Success = false,
                Message = "Can not find this member."
            };
        }
        else
        {
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Member>>();
        }

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

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://localhost:7089/api/member/get")
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenValidation.Token);

        using HttpResponseMessage response = await _http.SendAsync(request);


        if (response is null || response.IsSuccessStatusCode == false)
        {
            return new ServiceResponse<List<Member>>()
            {
                Success = false,
                Message = "Can not find any member."
            };
        } 
        else
        {
            return await response.Content.ReadFromJsonAsync<ServiceResponse<List<Member>>>();
        }
    }
}
