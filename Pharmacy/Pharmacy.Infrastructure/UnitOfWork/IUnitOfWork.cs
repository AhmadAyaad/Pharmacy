using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Repostiory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Medicine> MedicineRepository { get; }
        IMedicineRepository SpecificMedicineRepository { get; }
        IRepository<Unit> UnitRepository { get; }
        IUnitRepository SpecficUnitRepository { get; }
        IRepository<Supplier> SupplierRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
