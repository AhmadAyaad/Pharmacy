using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Domain.View;
using ZPharmacy.Infrastructure.Data;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class ProductQuantityRepository : Repository<ProductQuantity>, IProductQuantityRepository
    {
        public ProductQuantityRepository(PharmacyDbContext context) : base(context)
        {
        }
        public Task<ProductQuantity> GetProductByExpireDateAndProductId(DateTime expireDate, int productId)
        {
            return _context.ProductQuantities.SingleOrDefaultAsync(pq => pq.ExpireDate == expireDate && pq.ProductId == productId);
        }
        public Task<List<ProductQuantityDetailViewModel>> GetProductQuantityByProductIdAndPharmacyIdAsync(int productId, int pharmacyId)
        {
            return _context.ProductQuantities.Where(pq => pq.PharmacyId == pharmacyId && pq.ProductId == productId)
                                        .Select(pq =>
                                        new ProductQuantityDetailViewModel
                                        {
                                            ExpireDate = pq.ExpireDate,
                                            Quantity = pq.TotalProductQuantity,
                                            Price= pq.Price
                                        })
                                        .ToListAsync();
        }
    }
}
