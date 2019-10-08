using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Repository;

namespace Services
{
    public class MemberService : IService<Member>
    {
        private IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Delete(object input)
        {
            _unitOfWork.MemberRepository.Delete(input);
        }

        public IEnumerable<Member> GetAll()
        {
            _unitOfWork.MemberRepository.GetAll();
        }

        public Member GetOne(object input)
        {
            throw new NotImplementedException();
        }

        public void Insert(Member input)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Member input)
        {
            throw new NotImplementedException();
        }
    }
}
