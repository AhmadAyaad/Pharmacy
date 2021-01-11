using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Repostiory;
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
            SpecificMedicineRepository = new MedicineRepoistory(_context);
            UnitRepository = new Repostiory.Repository<Unit>(_context);
            SupplierRepository = new Repostiory.Repository<Supplier>(_context);
            SpecficUnitRepository = new UnitReposiotry(_context);
        }

        public IRepository<Medicine> MedicineRepository { get; }

        public IMedicineRepository SpecificMedicineRepository { get; }
        public IRepository<Unit> UnitRepository { get; }

        public IUnitRepository SpecficUnitRepository { get; }
        public IRepository<Supplier> SupplierRepository { get; }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
