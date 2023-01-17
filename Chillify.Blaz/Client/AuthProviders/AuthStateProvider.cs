using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Chillify.Blaz.Client.AuthProviders;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorage _localStorage;

    public AuthStateProvider(ILocalStorage localStorage)
    {
        _localStorage = localStorage;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal claimsPrincipal = await _localStorage.GetClaimsPrincipal();
        if (claimsPrincipal is null)
        {
            ClaimsIdentity anonymous = new();
            ClaimsPrincipal principal = new(anonymous);
            return await Task.FromResult(new AuthenticationState(principal));
        }

        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    }
    public void NotifyAuthenticationStateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
