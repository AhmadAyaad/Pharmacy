using System.ComponentModel.DataAnnotations;

namespace ZPharmacy.Core.Dtos
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public int? Phone { get; set; }
    }
}
