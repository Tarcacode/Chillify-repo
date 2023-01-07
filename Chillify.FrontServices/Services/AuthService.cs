using Chillify.Blaz.Shared.Dtos.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

    public async Task<ClaimsPrincipal> GetClaimsPrincipal()
    {
        string jwt = await _localStorage.GetToken();

        // when jwt read it and return the claims principal?
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadJwtToken(jwt);

        string name = securityToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
        string email = securityToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
        string role = securityToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

        var claims = securityToken.Claims;
        var identity = new ClaimsIdentity(claims, "myAuthType");

        return new ClaimsPrincipal(identity);
    }
}
