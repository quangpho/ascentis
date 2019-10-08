using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Services;
using Model;

namespace Acentis.Controllers
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
        public IActionResult RegisterMember([FromBody]Member member)
        {
            _memberService.Insert(member);
            _memberService.Save();
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("/member/authenticate")]
        public IActionResult Authenticate([FromBody]Member memberAuthen)
        {
            var member = _memberService.Authenticate(memberAuthen.Email, memberAuthen.Password);
            if (member == null)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }
            return Ok(member);
        }

        [HttpGet("/member")]
        public IActionResult GetAllMembers()
        {
            var members = _memberService.GetAll();
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
        public IActionResult GetMember([FromBody]int id)
        {
            var member = _memberService.GetOne(id);
            if (member == null)
            {
                return NotFound();
            }
            member.Password = null;
            return Ok(member);
        }

        [HttpPut("/member/update")]
        public IActionResult UpdateMember([FromBody]Member updatedMember)
        {
            var member = _memberService.GetOne(updatedMember.Id);
            if (member == null)
            {
                return NotFound();
            }
            member.DOB = updatedMember.DOB;
            member.EmailOptIn = updatedMember.EmailOptIn;
            member.Gender = updatedMember.Gender;
            member.MobileNumber = updatedMember.MobileNumber;
            member.Name = member.Name;
            _memberService.Update(member);
            _memberService.Save();
            return Ok();
        }
    }
}