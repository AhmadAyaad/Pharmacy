using Pharmacy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Domain.Entities
{
    public class ProductImportDetails
    {
        public int ProductImportDetailsId { get; set; }
        public int ImportOrderNumber { get; set; }
        public int SupplyOrderNumber { get; set; }
        public int ApprovalNumber { get; set; }
        public decimal PurchaseFee { get; set; }
        public ProductType ProductType { get; set; }
        public Supplier_Medicine_Pharmacy Supplier_Medicine_Pharmacy { get; set; }
    }
}
