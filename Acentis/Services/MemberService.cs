using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DAL.Repository;
using Helpers;
using DAL.Model;

namespace Services
{
    public class MemberService : IMemberService
    {
        private IUnitOfWork _unitOfWork;
        private readonly AppSetings _appSettings;
        public MemberService(IUnitOfWork unitOfWork, IOptions<AppSetings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }
        public Member Authenticate(string email, string password)
        {
            var members = _unitOfWork.MemberRepository.GetAllAsync();
            var member = members.SingleOrDefault(m => m.Email == email);
            if (member == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,member.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            member.Token = tokenHandler.WriteToken(token);

            member.Password = null;
            return member;
        }

        public void Delete(object input)
        {
            _unitOfWork.MemberRepository.Delete(input);
        }

        public IEnumerable<Member> GetAll()
        {
            return _unitOfWork.MemberRepository.GetAllAsync();
        }

        public Member GetOne(object input)
        {
            return _unitOfWork.MemberRepository.GetOne(input);
        }

        public void Insert(Member input)
        {
            if (string.IsNullOrWhiteSpace(input.Password))
            {
                throw new Exception("Password is required!");
            }
            var member = _unitOfWork.MemberRepository.GetOne(input.Email);
            if (member != null)
            {
                throw new Exception("Email is already taken!");
            }
            _unitOfWork.MemberRepository.Insert(input);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

        public void Update(Member input)
        {
            _unitOfWork.MemberRepository.Update(input);
        }

    }
}
