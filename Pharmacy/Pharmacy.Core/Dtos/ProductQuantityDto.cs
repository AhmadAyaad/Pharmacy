using Pharmacy.Domain.Entities;

namespace Pharmacy.Core.Dtos
{
    public class ProductQuantityDto
    {
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
    }
}
