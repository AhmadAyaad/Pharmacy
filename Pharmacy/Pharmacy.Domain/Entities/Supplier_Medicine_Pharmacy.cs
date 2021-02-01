using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Domain.Entities
{
    public class Supplier_Medicine_Pharmacy
    {
        public int Supplier_Medicine_Pharmacy_Id { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int? MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int? PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? Pharamcy_Supplier_Id { get; set; }
        public bool IsReturned { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<ProductImportDetails> ProductImportDetails { get; set; } = new HashSet<ProductImportDetails>();
    }
}
