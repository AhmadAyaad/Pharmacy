using System;

namespace Pharmacy.Domain.Entities
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string MedicineCode { get; set; }
        public string MedicineName { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual Unit Unit { get; set; }
    }
}
