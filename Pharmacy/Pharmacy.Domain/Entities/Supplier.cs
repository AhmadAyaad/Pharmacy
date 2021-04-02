using System;

namespace Pharmacy.Domain.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}