using Chillify.Blaz.Shared.Dtos.Auth;

namespace Chillify.FrontServices.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorage _localStorage;

    public AuthService(HttpClient http, ILocalStorage localStorage)
	{
        _http = http;
        _localStorage = localStorage;
    }

    public async Task<ServiceResponse<int>> Register(RegisterModel registerModel)
    {
        RegisterDto dto = new()
        {
            EmailAddress = registerModel.EmailAddress,
            Pseudo = registerModel.Pseudo,
            Password = registerModel.Password,
        };

        HttpResponseMessage response = await _http.PostAsJsonAsync("api/auth/register", dto);

        ServiceResponse<int> result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();

        return result;
    }

    public async Task<ServiceResponse<string>> Login(LoginDto loginDto)
    {
        HttpResponseMessage response = await _http.PostAsJsonAsync("api/auth/login", loginDto);

        ServiceResponse<string> result = await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();

        if (result.Success)
        {
            _localStorage.SetToken(result.Data);
        }

        return result;
    }

    public async Task Logout()
    {
        _localStorage.RemoveToken();
    }
}
