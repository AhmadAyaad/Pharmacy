using Pharmacy.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IProductImportDetailsService
    {
        Task<bool> CreateProductImport(CreateProductFromSupplierDto createProductFromSupplierDto);
    }
}
