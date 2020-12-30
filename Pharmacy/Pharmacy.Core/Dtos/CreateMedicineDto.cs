using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Dtos
{
    public class CreateMedicineDto
    {
        public string MedicineCode { get; set; }
        public string MedicineName { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime ExpireDate { get; set; }
        public int UnitId { get; set; }
    }
}
