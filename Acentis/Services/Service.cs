using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Service<T> : IService<T> where T : class
    {
        public void Delete(object input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetOne(object input)
        {
            throw new NotImplementedException();
        }

        public void Insert(T input)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T input)
        {
            throw new NotImplementedException();
        }
    }
}
