using Chillify.Blaz.Shared.Dtos.Auth;
using Chillify.Blaz.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chillify.Blaz.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            ServiceResponse<int> response = _authService.Register(registerDto);

            return response.Success == false ? BadRequest(response) : Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            ServiceResponse<string> response = _authService.Login(loginDto);

            return response.Success == false ? BadRequest(response) : Ok(response);
        }
    }
}
