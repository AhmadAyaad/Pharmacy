using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public class PharmacySupplyDetails
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PharmacyId { get; set; }
        public Pharmacy SupplierPharmacy { get; set; }
        public virtual ICollection<PharmacyProductsTransfer> PharmacyProductsTransfers { get; set; }
    }
}