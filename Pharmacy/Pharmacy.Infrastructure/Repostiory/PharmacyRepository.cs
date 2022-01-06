using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPharmacy.Domain;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.Enums;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Domain.View;
using ZPharmacy.Infrastructure.Data;
using ZPharmacy.Infrastructure.Extensions;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class PharmacyRepository : Repository<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(PharmacyDbContext context) : base(context)
        {
        }

        public Task<List<Pharmacy>> GetLargePharmaciesAsync()
        {
            return _context.Pharmacies.Where(p => p.PharmacyType == PharmacyTypeEnum.Large).ToListAsync();
        }

        public Task<IQueryable<ProductDetailQuantityView>> GetPharmacyProduct(int productId, int pharmacyId)
        {
            var product = (from pq in _context.ProductQuantities
                           join m in _context.Products
                           on new
                           { MedicineId = (int)pq.ProductId, PharamacyId = (int)pq.PharmacyId }
                           equals
                           new { MedicineId = m.Id, PharamacyId = pharmacyId }
                           join u in _context.Units
                           on m.UnitId equals u.Id
                           select new ProductDetailQuantityView { ProductsQuantity = pq, Medicine = m }
                           ).Where(p => p.Medicine.Id == productId);

            return Task.FromResult(product);
        }

        public async Task<PagedResultDTO<ProductQuantityView>> GetExistingPharmacyProductsAsync(int pharmacyId, int pageIndex, int pageSize)
        {
            return await (from pq in _context.ProductQuantities
                          join p in _context.Products
                          on new
                          { ProductId = pq.ProductId, PharamacyId = pq.PharmacyId }
                          equals
                          new { ProductId = p.Id, PharamacyId = pharmacyId }
                          join u in _context.Units
                          on p.UnitId equals u.Id
                          group pq by new
                          {
                              p.Id,
                              p.Name,
                              p.LocalCode,
                              p.NationalCode,
                              p.ProductType,
                              u.UnitName,
                              p.SellingPrice,
                              pq.PharmacyId,
                          } into g
                          select new ProductQuantityView
                          {
                              Id = g.Key.Id,
                              Name = g.Key.Name,
                              TotalQuantity = g.Where(p => p.TotalProductQuantity > 0).Sum(p => p.TotalProductQuantity),
                              LocalCode = g.Key.LocalCode,
                              NationalCode = g.Key.NationalCode,
                              UnitName = g.Key.UnitName,
                              ProductType = g.Key.ProductType.ToString(),
                          }).GetPagedAsync(pageIndex, pageSize);
        }
        public Task<bool> IsExistingPharmacyAsync(int pharmacyId)
        {
            return _context.Pharmacies.AnyAsync(p => p.Id == pharmacyId);
        }
    }
}