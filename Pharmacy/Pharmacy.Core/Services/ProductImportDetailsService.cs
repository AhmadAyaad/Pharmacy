using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Enums;
using Pharmacy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class ProductImportDetailsService : IProductImportDetailsService
    {
        readonly IRepository<ProductImportDetails> _productImportRepository;

        public ProductImportDetailsService(IRepository<ProductImportDetails> productImportRepository)
        {
            _productImportRepository = productImportRepository;
        }
        public async Task<bool> CreateProductImport(CreateProductFromSupplierDto createProductFromSupplierDto)
        {
            try
            {
                if (createProductFromSupplierDto != null)
                {
                    Enum.TryParse(createProductFromSupplierDto.ProductType, out ProductType productType);
                    var productImportDetails = new ProductImportDetails()
                    {

                        ImportOrderNumber = createProductFromSupplierDto.ImportOrderNumber,
                        ProductType = productType,
                        PurchaseFee = createProductFromSupplierDto.PurchaseFee,
                        SupplyOrderNumber = createProductFromSupplierDto.SupplyOrderNumber,
                        ApprovalNumber =createProductFromSupplierDto.ApprovalNumber
                    };
                    var isCreated = await _productImportRepository.Create(productImportDetails);
                    if (isCreated)
                        return true;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return false;
        }
    }
}
