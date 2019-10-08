﻿using DAL;
using Model;
using System;

namespace Repository
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

        public void Save()
        {
            context.SaveChanges();
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
