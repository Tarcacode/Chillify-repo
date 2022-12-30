
namespace Chillify.FrontServices.Services;

public class MemberService : IMemberService
{
    private readonly HttpClient _http;

    public MemberService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<List<Member>>> GetMembers()
    {
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
