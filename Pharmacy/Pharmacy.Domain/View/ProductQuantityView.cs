using System;
using System.Collections.Generic;

namespace ZPharmacy.Domain.View
{
    public class ProductQuantityView
    {
        public int Id { get; set; }
        public string ProductType { get; set; }
        public string UnitName { get; set; }
        public int TotalQuantity { get; set; }
        public string LocalCode { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductQuantityDetailViewModel> ProductQuantityDetailViewModels { get; set; }

    }
    public class ProductQuantityDetailViewModel
    {
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}