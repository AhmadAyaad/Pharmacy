using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Medicine> MedicineRepository { get; }
        IRepository<Unit> UnitRepository { get; }
        IRepository<Supplier> SupplierRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
