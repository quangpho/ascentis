using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repository
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
        public async Task Delete(object input)
        {
            T entity = await dbSet.FindAsync(input);
            dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetOne(object input)
        {
            return await dbSet.FindAsync(input);
        }

        public async Task Insert(T input)
        {
            await dbSet.AddAsync(input);
        }

        public void Update(T input)
        {
            dbSet.Update(input);
        }
    }
}
