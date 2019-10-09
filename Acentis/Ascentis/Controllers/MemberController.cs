using Ascentis.DAL.Model;
using Ascentis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ascentis.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterMember([FromBody]Member member)
        {
            try
            {
                await _memberService.InsertAsync(member);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberService.GetAllAsync();
            if (members == null)
            {
                return NotFound();
            }
            return Ok(members);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _memberService.GetAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMember([FromBody]Member updatedMember)
        {
            var result = await _memberService.UpdateAsync(updatedMember);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                await _memberService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}