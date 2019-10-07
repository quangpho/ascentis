using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetOne(object input);
        void Insert(T input);
        void Update(T input);
        void Delete(object input);
    }
}
