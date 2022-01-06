using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.View;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Domain.IRepository
{
    public interface IPharmacyRepository : IRepository<Pharmacy>
    {
        Task<PagedResultDTO<ProductQuantityView>> GetExistingPharmacyProductsAsync(int pharmacyId, int pageIndex, int pageSize);
        Task<IQueryable<ProductDetailQuantityView>> GetPharmacyProduct(int productId, int pharmacyId);
        Task<List<Pharmacy>> GetLargePharmaciesAsync();
        Task<bool> IsExistingPharmacyAsync(int pharmacyId);
    }
}