using System;
using System.Collections.Generic;

namespace Services
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetOne(object input);
        void Insert(T input);
        void Update(T input);
        void Delete(object input);
        void Save();
    }
}
