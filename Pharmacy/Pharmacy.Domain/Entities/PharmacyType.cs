using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Domain.Entities
{
    public class PharmacyType
    {
        public int PharmacyTypeId { get; set; }
        public string Type { get; set; }
        public bool ISEligibleToSellToPatients { get; set; } = false;
        public ICollection<Pharmacy> Pharmacies { get; set; } = new HashSet<Pharmacy>();
    }
}
