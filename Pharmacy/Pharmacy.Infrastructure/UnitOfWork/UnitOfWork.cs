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
            IRepository<SupplierProductsTransfer> supplierProductsTransferRepository,
            IRepository<Pharmacy.Domain.Entities.Pharmacy> pharmacyRepository,
            IPharmacyRepository specficpharmacyRepository,
            IRepository<ProductsQuantity> productsQuantityRepository,
            ISupplierProductsTransferReposiotry supplierProductsTransferReposiotry,
            IRepository<PharmacySupplyDetails> pharmacySupplyDetailsRepo,
            IRepository<PharmacyProductsTransfer> pharamcyProductsTransferRepo
            )
        {
            _context = context;
            MedicineRepository = medicineRepository;
            SpecificMedicineRepository = specificMedicineRepository;
            UnitRepository = unitRepository;
            SpecficUnitRepository = specficUnitRepository;
            SpecficSupplierProductsTransferReposiotry = supplierProductsTransferReposiotry;
            SupplierRepository = supplierRepository;
            ProductImportDetailsRepository = productImportDetailsRepository;
            SupplierProductsTransferRepository = supplierProductsTransferRepository;
            PharmacyRepository = pharmacyRepository;
            SpecficPharmacyRepository = specficpharmacyRepository;
            ProductsQuantityRepository = productsQuantityRepository;
            PharmacySupplyDetailsRepo = pharmacySupplyDetailsRepo;
            PharamcyProductsTransferRepo = pharamcyProductsTransferRepo;

        }

        public IRepository<Medicine> MedicineRepository { get; }

        public IMedicineRepository SpecificMedicineRepository { get; }
        public IRepository<Unit> UnitRepository { get; }

        public IUnitRepository SpecficUnitRepository { get; }
        public IRepository<Supplier> SupplierRepository { get; }

        public IRepository<ProductImportDetails> ProductImportDetailsRepository { get; }
        public IRepository<SupplierProductsTransfer> SupplierProductsTransferRepository { get; }

        public IRepository<Domain.Entities.Pharmacy> PharmacyRepository { get; }
        public IPharmacyRepository SpecficPharmacyRepository { get; }

        public ISupplierProductsTransferReposiotry SpecficSupplierProductsTransferReposiotry { get; }
        public IRepository<ProductsQuantity> ProductsQuantityRepository { get; }

        public IRepository<PharmacySupplyDetails> PharmacySupplyDetailsRepo { get; }

        public IRepository<PharmacyProductsTransfer> PharamcyProductsTransferRepo { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
