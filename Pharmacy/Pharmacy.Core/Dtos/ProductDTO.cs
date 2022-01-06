using System;
using System.ComponentModel.DataAnnotations;

namespace ZPharmacy.Core.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string LocalCode { get; set; }
        [Required]
        public string NationalCode { get; set; }
        [Required]
        public string Name { get; set; }
        public int ProductType { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
