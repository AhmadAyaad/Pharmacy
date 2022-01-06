using System;

namespace ZPharmacy.Domain.Entities
{
    public class SupplyOrderDetails : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string BatchNumber { get; set; }
        public int SupplyOrderNumber { get; set; }
        public int ApprovalNumber { get; set; }
        public decimal PurchaseFee { get; set; }
        public DateTime ExpireDate { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int SupplierOrdersId { get; set; }
        public virtual SupplyOrders SupplyOrders { get; set; }
    }
}