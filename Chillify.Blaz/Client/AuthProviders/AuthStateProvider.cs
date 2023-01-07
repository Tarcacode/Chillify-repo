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
        ClaimsPrincipal claimsPrincipal = await _authService.GetClaimsPrincipal();

        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    }

}
