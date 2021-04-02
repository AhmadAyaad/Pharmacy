using System;

namespace Pharmacy.Domain.Entities
{
    public class ProductsQuantity
    {
        public int ProductsQuantityId { get; set; }
        public int? PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int? MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int TotalProductQuantity { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Price { get; set; }
    }
}