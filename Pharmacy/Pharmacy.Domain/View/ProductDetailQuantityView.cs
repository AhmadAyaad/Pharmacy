using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Domain.View
{
    public class ProductDetailQuantityView
    {
        public ProductQuantity ProductsQuantity { get; set; }
        public virtual Product Medicine { get; set; }
    }
}