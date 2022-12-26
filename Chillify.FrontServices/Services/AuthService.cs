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
        var dto = new RegisterDto()
        {
            EmailAddress = registerModel.EmailAddress,
            Pseudo = registerModel.Pseudo,
            Password = registerModel.Password,
        };

        HttpResponseMessage response = await _http.PostAsJsonAsync("api/auth/register", dto);

        ServiceResponse<int> result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();

        return result;
    }
}
