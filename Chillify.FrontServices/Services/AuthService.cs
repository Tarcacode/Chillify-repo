using Chillify.Blaz.Shared.Dtos.Auth;

namespace Chillify.FrontServices.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
	{
        _http = http;
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

        // TODO: Put here the JWT in the browser storage
        // TODO: And look how to pass JWT in request header
        return result;
    }
}
