using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Domain.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public ICollection<Supplier_Medicine_Pharmacy> Supplier_Medicine_Pharmacies { get; set; }
                                                      = new HashSet<Supplier_Medicine_Pharmacy>();
    }
}
