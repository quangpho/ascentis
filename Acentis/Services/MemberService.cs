using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Repository;

namespace Services
{
    public class MemberService : IMemberService
    {
        private IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Member Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(object input)
        {
            _unitOfWork.MemberRepository.Delete(input);
        }

        public IEnumerable<Member> GetAll()
        {
            return _unitOfWork.MemberRepository.GetAll();
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
