using Pharmacy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Dtos
{
    public class CreateProductFromSupplierDto
    {
       
        public int ImportOrderNumber { get; set; }
        public int SupplyOrderNumber { get; set; }
        public int ApprovalNumber { get; set; }
        public decimal PurchaseFee { get; set; }
        public string ProductType { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public int PharmacyId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
