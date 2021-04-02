using System;

namespace Pharmacy.Core.Dtos
{
    public class PharamcyProductsTransferDTO
    {
        public int MedicineId { get; set; }
        public int PharmacyId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
