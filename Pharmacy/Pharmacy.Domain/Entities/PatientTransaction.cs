using System;

namespace Pharmacy.Domain.Entities
{
    public class PatientTransaction
    {
        public int PatientTransactionId { get; set; }
        public int? PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int? MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
