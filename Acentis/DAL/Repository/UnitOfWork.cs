using Ascentis.DAL.Context;
using Ascentis.DAL.Model;
using System;
using System.Threading.Tasks;

namespace Ascentis.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private MemberDbContext context;
        private Repository<Member> memberRepo;

        public UnitOfWork(MemberDbContext dbContext)
        {
            this.context = dbContext;
        }

        public Repository<Member> MemberRepository
        {
            get
            {
                if (this.memberRepo == null)
                {
                    this.memberRepo = new Repository<Member>(context);
                }
                return memberRepo;
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
