using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {
        private MemberDbContext context = new MemberDbContext();

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
