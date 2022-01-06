using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Core.Dtos
{
    public class ProductQuantityDto
    {
        public Product Medicine { get; set; }
        public int Quantity { get; set; }
    }
}
