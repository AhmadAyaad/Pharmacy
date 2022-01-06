using System.Threading.Tasks;
using ZPharmacy.Domain.IRepository;

namespace ZPharmacy.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepo { get; }
        IUnitRepository UnitRepo { get; }
        ISupplierRepository SupplierRepo { get; }
        ISupplierOrderDetailsRepository SupplierOrderDetailsRepo { get; }
        ISupplierOrderRepository SupplierOrderRepo { get; }
        IPharmacyRepository PharmacyRepo { get; }
        IProductQuantityRepository ProductQuantityRepo { get; }
        IAccountRepository AccountRepo {  get; }    
        //IRepository<InternalPharmacyOrderDetails> PharmacySupplyDetailsRepo { get; }
        //IRepository<PharmacyOrder> PharamcyProductsTransferRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
