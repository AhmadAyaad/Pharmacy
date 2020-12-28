using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IUnitOfWorkService
    {
        Task<int> SaveChagnesAsync();
    }
}
