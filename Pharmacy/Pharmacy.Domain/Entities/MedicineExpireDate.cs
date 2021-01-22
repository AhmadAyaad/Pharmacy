using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Domain.Entities
{
    public class MedicineExpireDate
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int ExpireDateId { get; set; }
        public ExpireDate ExpireDate { get; set; }
    }
}
