using DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository
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
        public void Delete(object input)
        {
            T entity = dbSet.Find(input);
            dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetOne(object input)
        {
            return dbSet.Find(input);
        }

        public void Insert(T input)
        {
            dbSet.Add(input);
        }

        public void Update(T input)
        {
            db.Entry(input).State = EntityState.Modified;
        }
    }
}
