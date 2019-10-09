using Ascentis.API.Model;
using Ascentis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ascentis.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticateService _authenticateService;

        [HttpPost("/member/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]LoginModel login)
        {
            var member = await _authenticateService.AuthenticateAsync(login.Email, login.Password);
            if (member == null)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }
            return Ok(member);
        }
    }
}