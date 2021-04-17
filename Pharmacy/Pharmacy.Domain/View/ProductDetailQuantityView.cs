using Pharmacy.Domain.Entities;

namespace Pharmacy.Domain.View
{
    public class ProductDetailQuantityView
    {
        public ProductsQuantity ProductsQuantity { get; set; }
        public Medicine Medicine { get; set; }
        public Unit unit { get; set; }
    }
}