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
    public class ProductSupplierService : IProductSupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductSupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> RecieveProductFromSupplier(CreateProductFromSupplierDto createProductFromSupplierDto)
        {
            try
            {
                if (createProductFromSupplierDto != null)
                {
                    var isCreated = await CreateProductImportDetails(createProductFromSupplierDto);
                    if (isCreated)
                    {
                        var isOperationCreated = await CreateNewProductTransferOperation(createProductFromSupplierDto);
                        if (isOperationCreated)
                        {
                            var result = await _unitOfWork.SaveChangesAsync();
                            if (result > 0)
                                return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return false;
        }



        private async Task<bool> CreateProductImportDetails(CreateProductFromSupplierDto createProductFromSupplierDto)
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
            return isCreated ? true : false;

        }

        private async Task<bool> CreateNewProductTransferOperation(CreateProductFromSupplierDto createProductFromSupplierDto)
        {
            var supplierProductsTransfer = new SupplierProductsTransfer()
            {
                MedicineId = createProductFromSupplierDto.ProductId,
                PharmacyId = createProductFromSupplierDto.PharmacyId,
                Price = createProductFromSupplierDto.Price,
                Quantity = createProductFromSupplierDto.Quantity
            };
            var isCreated = await _unitOfWork.SupplierProductsTransferRepository
                                  .Create(supplierProductsTransfer);
            return isCreated ? true : false;
        }
    }
}
