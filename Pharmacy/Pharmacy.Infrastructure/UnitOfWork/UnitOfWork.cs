using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Repostiory;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PharmacyDbContext _context;
 
        public UnitOfWork(PharmacyDbContext context, 
            IRepository<Medicine> medicineRepository,
            IMedicineRepository specificMedicineRepository,
            IRepository<Unit> unitRepository,
            IUnitRepository specficUnitRepository,
            IRepository<Supplier> supplierRepository, 
            IRepository<ProductImportDetails> productImportDetailsRepository,
            IRepository<Supplier_Medicine_Pharmacy> supplier_Medicine_PharmacyRepository,
            IRepository<Pharmacy.Domain.Entities.Pharmacy> pharmacyRepository,
            IPharmacyRepository specficPharmacyRepository
            )
        {
            _context = context;
            MedicineRepository = medicineRepository;
            SpecificMedicineRepository = specificMedicineRepository;
            UnitRepository = unitRepository;
            SpecficUnitRepository = specficUnitRepository;
            SupplierRepository = supplierRepository;
            ProductImportDetailsRepository = productImportDetailsRepository;
            Supplier_Medicine_PharmacyRepository = supplier_Medicine_PharmacyRepository;
            PharmacyRepository = pharmacyRepository;
            SpecficPharmacyRepository = specficPharmacyRepository;
        }

        public IRepository<Medicine> MedicineRepository { get; }

        public IMedicineRepository SpecificMedicineRepository { get; }
        public IRepository<Unit> UnitRepository { get; }

        public IUnitRepository SpecficUnitRepository { get; }
        public IRepository<Supplier> SupplierRepository { get; }

        public IRepository<ProductImportDetails> ProductImportDetailsRepository { get; }
        public IRepository<Supplier_Medicine_Pharmacy> Supplier_Medicine_PharmacyRepository { get; }

        public IRepository<Domain.Entities.Pharmacy> PharmacyRepository { get; }
        public IPharmacyRepository SpecficPharmacyRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
