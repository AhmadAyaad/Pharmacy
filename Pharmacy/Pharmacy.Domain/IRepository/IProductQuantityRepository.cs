using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.View;

namespace ZPharmacy.Domain.IRepository
{
    public interface IProductQuantityRepository : IRepository<ProductQuantity>
    {
        Task<ProductQuantity> GetProductByExpireDateAndProductId(DateTime expireDate, int productId);
        Task<List<ProductQuantityDetailViewModel>> GetProductQuantityByProductIdAndPharmacyIdAsync(int productId, int pharmacyId);
    }
}
