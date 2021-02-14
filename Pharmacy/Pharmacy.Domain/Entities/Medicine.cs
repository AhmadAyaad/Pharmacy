using Pharmacy.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string? MedicineCode { get; set; }
        public string NationalCode { get; set; }
        public string MedicineName { get; set; }
        public decimal? SellingPrice { get; set; }
        public ICollection<MedicineExpireDate> MedicineExpireDates { get; set; } = new HashSet<MedicineExpireDate>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? UnitId { get; set; }
        public virtual Unit Unit { get; set; } = new Unit();
        public ProductType ProductType { get; set; }
        public ICollection<Supplier_Medicine_Pharmacy> Supplier_Medicine_Pharmacies { get; set; }
                                                     = new HashSet<Supplier_Medicine_Pharmacy>();

        public ICollection<PatientTransaction> PatientTransactions { get; set; }
                                                      = new HashSet<PatientTransaction>();
    }
}
