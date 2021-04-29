using Pharmacy.Domain.Entities;

namespace Pharmacy.Domain.View
{
    public class ProductDetailQuantityView
    {
        public ProductsQuantity ProductsQuantity { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}