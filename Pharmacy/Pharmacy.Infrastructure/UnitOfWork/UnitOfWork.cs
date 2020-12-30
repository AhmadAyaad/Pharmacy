using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            MedicineRepository = new Repostiory.Repository<Medicine>(_context);
            UnitRepository = new Repostiory.Repository<Unit>(_context);
            SupplierRepository = new Repostiory.Repository<Supplier>(_context);

        }

        public IRepository<Medicine> MedicineRepository { get; }

        public IRepository<Unit> UnitRepository { get; }

        public IRepository<Supplier> SupplierRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
