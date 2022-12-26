namespace Chillify.Core.Interfaces;

public interface IAuthService
{
    ServiceResponse<int> Register(RegisterDto registerDto);
    ServiceResponse<string> Login(LoginDto loginDto);
}
