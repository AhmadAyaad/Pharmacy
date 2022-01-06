using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZPharmacy.Core.Dtos
{
    public class SupplyOrderDTO
    {
        public int ImportOrderNumber { get; set; }
        [Required]
        public List<SupplyOrderDetailsDTO> SupplyOrdersDetailsDTO { get; set; }

    }
}
