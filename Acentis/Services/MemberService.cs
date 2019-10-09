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

        public async Task DeleteAsync(object input)
        {
            await _unitOfWork.MemberRepository.DeleteAsync(input);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _unitOfWork.MemberRepository.GetAllAsync();
        }

        public async Task<Member> GetAsync(object input)
        {
            return await _unitOfWork.MemberRepository.GetAsync(input);
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

        public async Task UpdateAsync(Member input)
        {
            _unitOfWork.MemberRepository.Update(input);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
