using Newtonsoft.Json;

using System;
using System.Collections.Generic;

namespace Pharmacy.Core.Dtos
{
    public class CreateProductFromSupplierDto
    {
        public int ImportOrderNumber { get; set; }
        public int SupplyOrderNumber { get; set; }
        public int ApprovalNumber { get; set; }
        public decimal PurchaseFee { get; set; }
        public int SupplierId { get; set; }
        public List<ProductTransferDto> ProductTransfers { get; set; } = new List<ProductTransferDto>();
    }

    public class ProductTransferDto
    {
        [JsonProperty(PropertyName = "medicineId")]
        public int ProductId { get; set; }
        public int PharmacyId { get; set; }
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "itemQuantity")]
        public int Quantity { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
