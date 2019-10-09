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
    public class AuthenticateService : IAuthenticateService
    {
        private IUnitOfWork _unitOfWork;
        private readonly AppSetings _appSettings;

        public AuthenticateService(IUnitOfWork unitOfWork, IOptions<AppSetings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }
        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var member = await _unitOfWork.MemberRepository.FindAsync(m => m.Email == email && m.Password == password);
            if (member == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var token = new JwtSecurityToken
                (
                    issuer: "http://localhost:59726/",
                    audience: "http://localhost:59726/",
                    claims: new Claim[]
                    {
                        new Claim(ClaimTypes.Name,member.Id.ToString())
                    },
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
           
            var result = tokenHandler.WriteToken(token);

            return result;
        }
    }
}
