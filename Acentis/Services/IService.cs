﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ascentis.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(object input);
        Task<T> InsertAsync(T input);
        Task<T> UpdateAsync(T input);
        Task Delete(object input);
    }
}
