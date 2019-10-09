using DAL.Model;
using System;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Member> MemberRepository { get; }
        Task Save();
    }
}
