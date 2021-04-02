using System;

namespace Pharmacy.Domain.View
{
    public class ProductQuantityView
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string MedicineCode { get; set; }
        public string NationalCode { get; set; }
        public string ProductType { get; set; }
        public string UnitName { get; set; }

        //public DateTime? ExpireDate { get; set; }
        public decimal? SellingPrice { get; set; }

        public int? TotalQuantity { get; set; }
        public decimal? Price { get; set; }
    }
}