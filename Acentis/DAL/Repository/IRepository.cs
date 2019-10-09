using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetOne(object input);
        Task Insert(T input);
        void Update(T input);
        Task Delete(object input);
    }
}
