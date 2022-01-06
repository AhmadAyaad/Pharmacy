using System;

namespace ZPharmacy.Domain.Entities
{
    public class ProductQuantity
    {
        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int TotalProductQuantity { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Price { get; set; }
    }
}