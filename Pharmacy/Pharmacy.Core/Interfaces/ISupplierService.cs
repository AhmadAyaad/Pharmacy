using Pharmacy.Core.Dtos;
using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface ISupplierService
    {
        Task<bool> CreateSupplier(CreateSupplierDto createSupplierDto);
        Task<List<Supplier>> GetSuppliers();
    }
}
