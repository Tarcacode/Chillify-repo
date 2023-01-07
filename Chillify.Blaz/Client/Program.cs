using Chillify.Blaz.Client;
using Chillify.Blaz.Client.AuthProviders;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Security.Claims;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILocalStorage, LocalStorage>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddAuthorizationCore(options => 
    {
        options.AddPolicy("manager+", policy => policy.RequireClaim("role", "4", "5"));
    });

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
