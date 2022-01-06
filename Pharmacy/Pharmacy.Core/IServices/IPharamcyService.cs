using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Domain.View;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.IServices
{
    public interface IPharamcyService
    {
        Task<Response<List<LargePharmacyDTO>>> GetLargePharmacies();

        Task<Response<PagedResultDTO<ProductQuantityView>>> GetExistingPharmacyProductsAsync(int pharmacyId, int pageIndex, int pageSize);

        Task<Response<ProductQuantityView>> GetPharmacyProductDetailsAsync(int pharmacyId, int productId);

        //Response<Task<IQueryable<ProductDetailQuantityView>>> GetPharmacyProduct(int productId, int pharmacyId);

        //Response<Task<Domain.Entities.Pharmacy>> GetPharmacyById(int id);
    }
}