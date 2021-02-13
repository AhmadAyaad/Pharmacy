using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Domain.Entities
{
    public class ExpireDate
    {
        public int ExpireDateId { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireationDate { get; set; }
        public ICollection<MedicineExpireDate> MedicineExpireDates { get; set; } = new HashSet<MedicineExpireDate>();
    }
}
