using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Infrastructure.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                    var productImportDetails = await CreateProductImportDetails(createProductFromSupplierDto);
                    if (productImportDetails != null)
                    {
                        var isOperationCreated = await CreateNewProductTransferOperation(createProductFromSupplierDto,
                                                                                        productImportDetails);

                        if (isOperationCreated)
                        {
                            var mappedProductsQuantiesList =
                                MapToProductQuantities(createProductFromSupplierDto.ProductTransfers);

                            //List<ProductsQuantity> existingProductsWithSameExprieDateList = new List<ProductsQuantity>();
                            List<ProductsQuantity> productsWithNewExprieDateList = new List<ProductsQuantity>();

                            //List<ProductsQuantity> exisitingProducts = new List<ProductsQuantity>();
                            var productQuantitiesFromDb = _unitOfWork.ProductsQuantityRepository.GetAll();
                            //foreach (var item in productQuantitiesFromDb)
                            //{
                            //    //exisiting products in the db 
                            //    exisitingProducts =
                            //         mappedProductsQuantiesList
                            //         .Where(pr => pr.ExpireDate == item.ExpireDate && pr.MedicineId == item.MedicineId)
                            //         .ToList();
                            //    existingProductsWithSameExprieDateList.AddRange(exisitingProducts);

                            //}
                            List<ProductsQuantity> existingProductsWithSameExprieDateList =
                                GetExisitngProductsFromDbWithSameExpireDate(productQuantitiesFromDb, mappedProductsQuantiesList);

                            productsWithNewExprieDateList = GetNonExisitingProducts(mappedProductsQuantiesList,
                                                                                   existingProductsWithSameExprieDateList);

                            // lw el expiredate mwgod abl keda
                            //if (existingProductsWithSameExprieDateList.Count > 0)
                            //{
                            //    foreach (var item in existingProductsWithSameExprieDateList)
                            //    {
                            //        var exisitingProductQuanity = _unitOfWork.ProductsQuantityRepository
                            //                                      .Find(pq => pq.MedicineId == (int)item.MedicineId
                            //                                      && pq.ExpireDate == item.ExpireDate)
                            //                                      .FirstOrDefault();
                            //        exisitingProductQuanity.TotalProductQuantity = item.TotalProductQuantity
                            //                                                    + exisitingProductQuanity.TotalProductQuantity;
                            //        await _unitOfWork.ProductsQuantityRepository.Update(exisitingProductQuanity);
                            //    }
                            //}


                            await UpdateExisitngProduct(existingProductsWithSameExprieDateList);

                            //if (productsWithNewExprieDateList.Count > 0)
                            //{
                            //    foreach (var productQuantity in productsWithNewExprieDateList)
                            //    {
                            //        await _unitOfWork.ProductsQuantityRepository.Create(productQuantity);
                            //    }
                            //}
                            await AddProductsWithNewExpireationDate(productsWithNewExprieDateList);

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

        private List<ProductsQuantity> GetNonExisitingProducts(List<ProductsQuantity> mappedProductsQuantiesList,
                                                               List<ProductsQuantity> existingProductsWithSameExprieDateList)
        {
            var productsWithNewExprieDateList = mappedProductsQuantiesList
                                                        .Except(existingProductsWithSameExprieDateList)
                                                        .ToList();
            return productsWithNewExprieDateList;
        }
        private async Task AddProductsWithNewExpireationDate(List<ProductsQuantity> productsWithNewExprieDateList)
        {
            if (productsWithNewExprieDateList.Count > 0)
            {
                foreach (var productQuantity in productsWithNewExprieDateList)
                {
                    await _unitOfWork.ProductsQuantityRepository.Create(productQuantity);
                }
            }

        }


        private async Task UpdateExisitngProduct(List<ProductsQuantity> existingProductsWithSameExprieDateList)
        {
            if (existingProductsWithSameExprieDateList.Count > 0)
            {
                foreach (var item in existingProductsWithSameExprieDateList)
                {
                    var exisitingProductQuanity = _unitOfWork.ProductsQuantityRepository
                                                  .Find(pq => pq.MedicineId == (int)item.MedicineId
                                                  && pq.ExpireDate == item.ExpireDate)
                                                  .FirstOrDefault();
                    exisitingProductQuanity.TotalProductQuantity = item.TotalProductQuantity
                                                                + exisitingProductQuanity.TotalProductQuantity;
                    await _unitOfWork.ProductsQuantityRepository.Update(exisitingProductQuanity);
                }
            }
        }

        private List<ProductsQuantity> GetExisitngProductsFromDbWithSameExpireDate(IQueryable<ProductsQuantity> productQuantitiesFromDb,
                                                                                    List<ProductsQuantity> mappedProductsQuantiesList)
        {
            List<ProductsQuantity> exisitingProducts = new List<ProductsQuantity>();
            List<ProductsQuantity> existingProductsWithSameExprieDateList = new List<ProductsQuantity>();

            foreach (var item in productQuantitiesFromDb)
            {
                //exisiting products in the db 
                exisitingProducts =
                     mappedProductsQuantiesList
                     .Where(pr => pr.ExpireDate == item.ExpireDate && pr.MedicineId == item.MedicineId)
                     .ToList();
                existingProductsWithSameExprieDateList.AddRange(exisitingProducts);

            }
            return existingProductsWithSameExprieDateList;
        }
        private async Task<ProductImportDetails> CreateProductImportDetails(CreateProductFromSupplierDto createProductFromSupplierDto)
        {
            try
            {

                var productImportDetails = new ProductImportDetails()
                {
                    ApprovalNumber = createProductFromSupplierDto.ApprovalNumber,
                    ImportOrderNumber = createProductFromSupplierDto.ImportOrderNumber,
                    SupplyOrderNumber = createProductFromSupplierDto.SupplyOrderNumber,
                    PurchaseFee = createProductFromSupplierDto.PurchaseFee,
                    SupplierId = createProductFromSupplierDto.SupplierId,
                };
                await _unitOfWork.ProductImportDetailsRepository.Create(productImportDetails);
                return productImportDetails;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private async Task<bool> CreateNewProductTransferOperation(CreateProductFromSupplierDto createProductFromSupplierDto,
                                                                    ProductImportDetails productImportDetails)
        {
            if (createProductFromSupplierDto.ProductTransfers.Count > 0)
            {
                var list = MapToSupplierProductsTransfer(createProductFromSupplierDto, productImportDetails);
                var isCreated = await _unitOfWork.SpecficSupplierProductsTransferReposiotry.AddRangeAsync(list);

                return isCreated ? true : false;
            }
            return false;
        }
        private List<SupplierProductsTransfer> MapToSupplierProductsTransfer(CreateProductFromSupplierDto createProductFromSupplierDto,
                        ProductImportDetails productImportDetails)
        {
            List<SupplierProductsTransfer> suppliersProductsTransferList = new List<SupplierProductsTransfer>();
            foreach (var item in createProductFromSupplierDto.ProductTransfers)
            {
                suppliersProductsTransferList.Add(
                    new SupplierProductsTransfer
                    {
                        ExpireDate = item.ExpireDate,
                        MedicineId = item.ProductId,
                        PharmacyId = item.PharmacyId,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ProductImportDetails = productImportDetails
                    });
            }
            return suppliersProductsTransferList;
        }

        private List<ProductsQuantity> MapToProductQuantities(List<ProductTransferDto> productTransferListDto)
        {
            List<ProductsQuantity> productsQuantities = new List<ProductsQuantity>();
            for (int i = 0; i < productTransferListDto.Count; i++)
            {
                productsQuantities.Add(new ProductsQuantity
                {
                    MedicineId = productTransferListDto[i].ProductId,
                    PharmacyId = productTransferListDto[i].PharmacyId,
                    ExpireDate = productTransferListDto[i].ExpireDate,
                    TotalProductQuantity = productTransferListDto[i].Quantity,
                    Price = productTransferListDto[i].Price
                }
                );
            }
            return productsQuantities;
        }
    }
}
