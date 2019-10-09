using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Ascentis.DAL.Repository;
using Ascentis.Helpers;
using Ascentis.DAL.Model;
using System.Threading.Tasks;

namespace Ascentis.Services
{
    public class MemberService : IMemberService
    {
        private IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork, IOptions<AppSetings> appSettings)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Delete(object input)
        {
            var entity = await _unitOfWork.MemberRepository.GetAsync(input);
            if (entity == null)
            {
                throw new Exception("Member is not found");
            }
            _unitOfWork.MemberRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            var members = await _unitOfWork.MemberRepository.GetAllAsync();
            if (members != null)
            {
                members = members.Select(m =>
                {
                    m.Password = null;
                    return m;
                });
            }
            return members;
        }

        public async Task<Member> GetAsync(object input)
        {
            var member = await _unitOfWork.MemberRepository.GetAsync(input);
            if (member != null)
            {
                member.Password = null;
            }
            return member;
        }

        public async Task<Member> InsertAsync(Member input)
        {
            if (string.IsNullOrWhiteSpace(input.Password))
            {
                throw new Exception("Password is required!");
            }
            var member = _unitOfWork.MemberRepository.GetAllAsync().Result.FirstOrDefault(m => m.Email == input.Email);
            if (member != null)
            {
                throw new Exception("Email is already taken!");
            }
            await _unitOfWork.MemberRepository.InsertAsync(input);
            await _unitOfWork.SaveChangesAsync();
            return input;
        }

        public async Task<Member> UpdateAsync(Member input)
        {
            var member = await _unitOfWork.MemberRepository.GetAsync(input.Id);

            if (member == null)
            {
                return null;
            }
            member.DOB = input.DOB;
            member.EmailOptIn = input.EmailOptIn;
            member.Gender = input.Gender;
            member.MobileNumber = input.MobileNumber;
            member.Name = input.Name;

            _unitOfWork.MemberRepository.Update(member);
            await _unitOfWork.SaveChangesAsync();
            return member;
        }
    }
}
