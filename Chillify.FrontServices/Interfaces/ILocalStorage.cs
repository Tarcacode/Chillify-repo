namespace Chillify.FrontServices.Interfaces;

public interface ILocalStorage
{
    Task SetToken(string jwt);
    Task<string> GetToken();
    Task RemoveToken();
    Task<bool> HasToken();
}
