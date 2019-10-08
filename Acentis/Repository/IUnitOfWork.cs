using Model;
using System;

namespace Repository
{
    public interface IUnitOfWork:IDisposable
    {
        Repository<Member> MemberRepository { get; }
        void Save();
    }
}
