using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Enums;
using Pharmacy.Infrastructure.UnitOfWork;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class ProductImportDetailsService : IProductImportDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductImportDetailsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                        ApprovalNumber = createProductFromSupplierDto.ApprovalNumber
                    };
                    var isCreated = await _unitOfWork.ProductImportDetailsRepository.Create(productImportDetails);
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
