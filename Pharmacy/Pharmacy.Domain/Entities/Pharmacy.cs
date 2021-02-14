using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public class Pharmacy
    {
        public int PharmacyId { get; set; }
        public int? ParentPharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public virtual Pharmacy ParentPharmacy { get; set; }
        public virtual HashSet<Pharmacy> ChildrenPharmacies { get; set; } = new HashSet<Pharmacy>();
        public PharmacyType PharmacyType { get; set; }
        public ICollection<Supplier_Medicine_Pharmacy> Supplier_Medicine_Pharmacies { get; set; }
                                                      = new HashSet<Supplier_Medicine_Pharmacy>();

        public ICollection<PatientTransaction> PatientTransactions { get; set; }
                                                      = new HashSet<PatientTransaction>();

    }
}
