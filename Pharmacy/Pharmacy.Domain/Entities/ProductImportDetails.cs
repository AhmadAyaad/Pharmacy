using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public class ProductImportDetails
    {
        public int ProductImportDetailsId { get; set; }
        public int ImportOrderNumber { get; set; }
        public int SupplyOrderNumber { get; set; }
        public int ApprovalNumber { get; set; }
        public decimal PurchaseFee { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public decimal TotalPricePerProduct { get; set; } = 0;
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<SupplierProductsTransfer> SupplierProductsTransfer { get; set; } =
                                        new HashSet<SupplierProductsTransfer>();
    }
}