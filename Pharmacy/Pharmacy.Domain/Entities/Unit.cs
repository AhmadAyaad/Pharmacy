using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Domain.Entities
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int? MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
