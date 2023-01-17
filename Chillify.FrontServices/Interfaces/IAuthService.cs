using Chillify.Blaz.Shared.Dtos.Auth;
using System.Security.Claims;

namespace Chillify.FrontServices.Interfaces;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(RegisterModel registerModel);
    Task<ServiceResponse<string>> Login(LoginDto loginDto);
    Task Logout();
}
