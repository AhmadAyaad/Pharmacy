using System.Collections.Generic;
using ZPharmacy.Domain.Enums;

namespace ZPharmacy.Domain.Entities
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public int? ParentPharmacyId { get; set; }
        public string Name { get; set; }
        public virtual Pharmacy ParentPharmacy { get; set; }
        public virtual ICollection<Pharmacy> ChildrenPharmacies { get; set; }
        public PharmacyTypeEnum PharmacyType { get; set; }
        public bool ISEligibleToSellToPatients { get; set; } = false;
    }
}