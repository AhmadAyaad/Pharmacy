using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Domain.Entities
{
    public class PharmacyProductsTransfer
    {
        public int id { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Column("pharmacy_Recviver_Id")]
        public int PharmacyId { get; set; }

        public Pharmacy ReciverPharmacy { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ExpireDate { get; set; }
        public PharmacySupplyDetails PharmacySupplyDetails { get; set; }
    }
}