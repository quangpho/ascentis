using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ascentis.DAL.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(object input);
        Task InsertAsync(T input);
        void Update(T input);
        Task DeleteAsync(object input);
        Task<T> FindAsync(Expression<Func<T, bool>> where);
    }
}
