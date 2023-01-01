using Chillify.FrontServices.Interfaces;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Chillify.FrontServices.Services;

public class LocalStorage : ILocalStorage
{
    private const string _TOKENNAME = "chillifytoken";
    private readonly IJSRuntime _jsRuntime;

    public LocalStorage(IJSRuntime jsRuntime)
	{
        _jsRuntime = jsRuntime;
    }

    public async Task SetToken(string jwt)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", _TOKENNAME, JsonSerializer.Serialize(jwt));
    }
    public async Task<string> GetToken()
    {
        string token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", _TOKENNAME);

        return token is null ? string.Empty : JsonSerializer.Deserialize<string>(token);
    }
    public async Task RemoveToken()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", _TOKENNAME);
    }
    public async Task<bool> HasToken()
    {
        string token = await GetToken();

        return token != string.Empty;
    }
}
