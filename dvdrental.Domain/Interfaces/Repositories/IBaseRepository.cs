using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dvdrental.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<bool> Add(T entity);
        Task<bool> Delete(T entity);
    }
}
