using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Domain.View;
using Pharmacy.Infrastructure.Data;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public class PharmacyRepository : Repository<Pharmacy.Domain.Entities.Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(PharmacyDbContext context) : base(context)
        {
        }

        public Task<IQueryable<ProductDetailQuantityView>> GetPharmacyProduct(int productId, int pharmacyId)
        {
            var product = (from pq in _context.ProductsQuantities
                           join m in _context.Medicines
                           on new
                           { MedicineId = (int)pq.MedicineId, PharamacyId = (int)pq.PharmacyId }
                           equals
                           new { MedicineId = m.MedicineId, PharamacyId = pharmacyId }
                           join u in _context.Units
                           on m.UnitId equals u.UnitId
                           select new ProductDetailQuantityView { ProductsQuantity = pq, Medicine = m }
                           ).Where(p => p.Medicine.MedicineId == productId);

            return Task.FromResult(product);
        }

        public Task<IQueryable<ProductQuantityView>> GetPharmacyProducts(int pharmacyId)
        {
            var query = (from pq in _context.ProductsQuantities
                         join m in _context.Medicines
                         on new
                         { MedicineId = (int)pq.MedicineId, PharamacyId = (int)pq.PharmacyId }
                         equals
                         new { MedicineId = m.MedicineId, PharamacyId = pharmacyId }
                         join u in _context.Units
                         on m.UnitId equals u.UnitId
                         group pq by new
                         {
                             m.MedicineId,
                             m.MedicineName,
                             m.MedicineCode,
                             m.NationalCode,
                             m.ProductType,
                             u.UnitName,
                             m.SellingPrice,
                             pq.PharmacyId
                         } into g
                         select new ProductQuantityView
                         {
                             Id = g.Key.MedicineId,
                             MedicineName = g.Key.MedicineName,
                             TotalQuantity = g.Sum(p => p.TotalProductQuantity),
                             MedicineCode = g.Key.MedicineCode,
                             NationalCode = g.Key.NationalCode,
                             SellingPrice = (decimal)g.Key.SellingPrice,
                             UnitName = g.Key.UnitName,
                             ProductType = g.Key.ProductType.ToString()
                         });
            return Task.FromResult(query);
        }
    }
}