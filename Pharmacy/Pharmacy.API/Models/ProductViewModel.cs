using System.ComponentModel.DataAnnotations;
using ZPharmacy.Domain.Enums;

namespace ZPharmacy.API.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int UnitId { get; set; }
        public ProductTypeEnum ProductType { get; set; }
    }
}
