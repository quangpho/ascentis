using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Repository
{
    public interface IUnitOfWork:IDisposable
    {
        Repository<Member> MemberRepository { get; }
        void Save();
    }
}
