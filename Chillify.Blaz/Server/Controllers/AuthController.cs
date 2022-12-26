using Chillify.Blaz.Shared.Dtos.Auth;
using Chillify.Blaz.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chillify.Blaz.Server.Controllers
{
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
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
