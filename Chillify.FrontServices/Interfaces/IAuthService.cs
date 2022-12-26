namespace Chillify.FrontServices.Interfaces;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(RegisterModel registerModel);
}
