using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Dtos
{
    public class ProductQuantityDto
    {
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
    }
}
