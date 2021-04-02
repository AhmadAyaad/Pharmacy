using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Repostiory;

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
        IRepository<ProductImportDetails> ProductImportDetailsRepository { get; }
        IRepository<SupplierProductsTransfer> SupplierProductsTransferRepository { get; }
        ISupplierProductsTransferReposiotry SpecficSupplierProductsTransferReposiotry { get; }
        IRepository<Pharmacy.Domain.Entities.Pharmacy> PharmacyRepository { get; }
        IPharmacyRepository SpecficPharmacyRepository { get; }
        IRepository<ProductsQuantity> ProductsQuantityRepository { get; }
        IRepository<PharmacySupplyDetails> PharmacySupplyDetailsRepo { get; }
        IRepository<PharmacyProductsTransfer> PharamcyProductsTransferRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
