using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Chillify.Blaz.Client.AuthProviders;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly IAuthService _authService;

    public AuthStateProvider(IAuthService authService)
    {
        _authService = authService;
    }
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        await Task.Delay(1500);

        //TODO: Read JWT here and put the claimprincipal in anonymous.
        //List<Claim> claims = new()
        //{

        //};

        //var anonymous = new ClaimsIdentity();
        var claimsPrincipal = await _authService.GetClaimsPrincipal();
        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    }

}
