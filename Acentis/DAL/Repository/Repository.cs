using Ascentis.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ascentis.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MemberDbContext db;
        private DbSet<T> dbSet;

        public Repository(MemberDbContext dbContext)
        {
            db = dbContext;
            dbSet = db.Set<T>();
        }
        public async Task DeleteAsync(object input)
        {
            T entity = await dbSet.FindAsync(input);
            dbSet.Remove(entity);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> where)
        {
            return await dbSet.FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(object input)
        {
            return await dbSet.FindAsync(input);
        }

        public async Task InsertAsync(T input)
        {
            await dbSet.AddAsync(input);
        }

        public void Update(T input)
        {
            dbSet.Update(input);
        }
    }
}
