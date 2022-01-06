using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Domain.IRepository
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<bool> IsSupplierNameExistsAsync(Supplier supplier);
        Task<bool> IsSupplierPhoneExistsAsync(Supplier supplier);
        Task<PagedResultDTO<Supplier>> GetPagedSuppliersAsync(int pageIndex ,int pageSize);
    }
}
