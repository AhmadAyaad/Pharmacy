using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<bool> Create(T t);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Update(T t);
        Task<bool> Delete(T t);
    }
}
