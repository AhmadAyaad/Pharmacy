using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface ISupplierService
    {
        Task<bool> CreateSupplier(Supplier supplier);
        Task<IEnumerable<Supplier>> GetSuppliers();
    }
}
