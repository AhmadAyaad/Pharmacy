﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Dtos
{
    public class CreateSupplierDto
    {
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
    }
}