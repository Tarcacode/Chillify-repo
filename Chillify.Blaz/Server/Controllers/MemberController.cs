using Chillify.Blaz.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chillify.Blaz.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [Authorize(Roles ="4, 5")]
        [HttpGet("get")]
        public IActionResult GetMembers()
        {
            ServiceResponse<List<Member>> response = _memberService.GetMembers();

            return response.Success == false ? NotFound(response) : Ok(response);
        }

        [Authorize(Roles = "4, 5")]
        [HttpGet("get/{id:int}")]
        public IActionResult GetMemberById([FromRoute] int id)
        {
            ServiceResponse<Member> response = _memberService.GetMember(id);

            return response.Success == false ? NotFound(response) : Ok(response);
        }
    }
}
