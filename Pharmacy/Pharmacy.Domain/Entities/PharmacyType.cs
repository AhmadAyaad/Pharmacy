using Pharmacy.Domain.Enums;

using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public class PharmacyType
    {
        public int PharmacyTypeId { get; set; }
        public PharmacyTypeEnum PharmacyTypeEnum { get; set; }
        public bool ISEligibleToSellToPatients { get; set; } = false;
        public ICollection<Pharmacy> Pharmacies { get; set; } = new HashSet<Pharmacy>();
    }
}