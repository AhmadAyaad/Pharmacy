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
            MedicineRepository = new Repository<Medicine>(_context);
            SpecificMedicineRepository = new MedicineRepoistory(_context);
            UnitRepository = new Repository<Unit>(_context);
            SupplierRepository = new Repository<Supplier>(_context);
            SpecficUnitRepository = new UnitReposiotry(_context);
            ProductImportDetailsRepository = new Repository<ProductImportDetails>(_context);
            Supplier_Medicine_PharmacyRepository = new Repository<Supplier_Medicine_Pharmacy>(_context);
        }

        public IRepository<Medicine> MedicineRepository { get; }

        public IMedicineRepository SpecificMedicineRepository { get; }
        public IRepository<Unit> UnitRepository { get; }

        public IUnitRepository SpecficUnitRepository { get; }
        public IRepository<Supplier> SupplierRepository { get; }

        public IRepository<ProductImportDetails> ProductImportDetailsRepository { get; }
        public IRepository<Supplier_Medicine_Pharmacy> Supplier_Medicine_PharmacyRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
