using Microsoft.EntityFrameworkCore;
using System;

namespace Pharmacy.Infrastructure.Views
{
    [Keyless]
    public class PharmacyProducts
    {
        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public string SupplierName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
