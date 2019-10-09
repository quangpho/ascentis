using Ascentis.DAL.Model;
using System;
using System.Threading.Tasks;

namespace Ascentis.DAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Member> MemberRepository { get; }
        Task SaveChangesAsync();
    }
}
