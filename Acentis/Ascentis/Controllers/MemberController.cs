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
        [HttpPost("/member/register")]
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

        [HttpGet("/member")]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberService.GetAllAsync();
            if (members == null)
            {
                return NotFound();
            }
            members = members.Select(m =>
            {
                m.Password = null;
                return m;
            });
            return Ok(members);
        }

        [HttpGet("/member/{id}")]
        public async Task<IActionResult> GetMember([FromBody]int id)
        {
            var member = await _memberService.GetAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            member.Password = null;
            return Ok(member);
        }

        [HttpPut("/member/update")]
        public async Task<IActionResult> UpdateMember([FromBody]Member updatedMember)
        {
            var member = await _memberService.GetAsync(updatedMember.Id);
            if (member == null)
            {
                return NotFound();
            }
            member.DOB = updatedMember.DOB;
            member.EmailOptIn = updatedMember.EmailOptIn;
            member.Gender = updatedMember.Gender;
            member.MobileNumber = updatedMember.MobileNumber;
            member.Name = member.Name;
            await _memberService.UpdateAsync(member);
            return Ok();
        }
    }
}