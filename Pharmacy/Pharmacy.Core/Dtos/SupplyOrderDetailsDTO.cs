using System;

namespace ZPharmacy.Core.Dtos
{
    public class SupplyOrderDetailsDTO
    {
        public int ProductId { get; set; }
        public int PharmacyId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string BatchNumber { get; set; }
        public int SupplyOrderNumber { get; set; }
        public int ApprovalNumber { get; set; }
        public decimal PurchaseFee { get; set; }
        public DateTime ExpireDate { get; set; }
        public int SupplierId { get; set; }
    }
}
