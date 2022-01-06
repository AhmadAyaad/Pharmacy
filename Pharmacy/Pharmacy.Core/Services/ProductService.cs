using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.EventHandler;
using ZPharmacy.Core.Helpers;
using ZPharmacy.Core.IServices;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.Enums;
using ZPharmacy.Infrastructure.UnitOfWork;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public static EventHandler<NotificationEventArgs> OnBla;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Response<Task<bool>> AddRangeAsync(List<Product> medicines)
        //{
        //    _unitOfWork.ProductRepo.AddRangeAsync(medicines);
        //    await _unitOfWork.SaveChangesAsync();
        //}


        public async Task<Response> AddNewProductAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            if (await _unitOfWork.ProductRepo.IsProudctLocalCodeExistsAsync(product))
                return new Response(ResponseStatus.Failed, "يوجد منتج بهذا الكود المحلى");
            if (await _unitOfWork.ProductRepo.IsProudctNationalCodeExistsAsync(product))
                return new Response(ResponseStatus.Failed, "يوجد منتج بهذا الكود الدولى");
            await _unitOfWork.ProductRepo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }


        public async Task<PagedResultDTO<ProductDTO>> GetPaginatedProductsAsync(PaginationFilter paginationFilter)
        {
            var pagedResultProducts = await _unitOfWork.ProductRepo.GetProductsAsync(paginationFilter.PageSize, paginationFilter.PageNumber);
            pagedResultProducts = pagedResultProducts ?? new PagedResultDTO<Product>();
            return new PagedResultDTO<ProductDTO>
            {
                Items = _mapper.Map<List<ProductDTO>>(pagedResultProducts.Items),
                RowCount = pagedResultProducts.RowCount
            };
        }

        public async Task<Response> DeleteProductAsync(int productId)
        {
            var existingProduct = await _unitOfWork.ProductRepo.GetByIdAsync(productId);
            if (existingProduct is null)
                return new Response(ResponseStatus.NotFound, $"There is no products with this id: {productId}");
            _unitOfWork.ProductRepo.Remove(existingProduct);
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }

        public async Task<Response<ProductDTO>> GetProductAsync(int id)
        {
            var existingProduct = await _unitOfWork.ProductRepo.GetProductWithUnitNameAsync(id);
            if (existingProduct is null)
                return new Response<ProductDTO>(null, ResponseStatus.NotFound, $"Cannot find product with provied id: {id}");
            return new Response<ProductDTO>(_mapper.Map<ProductDTO>(existingProduct));
        }

        public async Task<Response> UpdateProductAsync(ProductDTO productDTO)
        {
            var exisitngProduct = await _unitOfWork.ProductRepo.GetByIdAsync(productDTO.Id);
            if (exisitngProduct is null)
                return new Response(ResponseStatus.NotFound, $"Cannot find the product to update");

            exisitngProduct.LocalCode = productDTO.LocalCode;
            exisitngProduct.Name = productDTO.Name;
            exisitngProduct.NationalCode = productDTO.NationalCode;
            exisitngProduct.ProductType = (ProductTypeEnum)productDTO.ProductType;
            exisitngProduct.UnitId = productDTO.UnitId;
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }

        public async Task<Response<List<ProductDTO>>> GetProductsAsync()
        {
            var products = await _unitOfWork.ProductRepo.GetAllAsync();
            if (products is null)
                return new Response<List<ProductDTO>>(new List<ProductDTO>());
            return new Response<List<ProductDTO>>(_mapper.Map<List<ProductDTO>>(products));
        }

        //public async Task<PagedResponse<List<Product>>> GetMedicines(PaginationFilter validFilter)
        //{
        //    try
        //    {
        //        var medicinesQuery = _unitOfWork.ProductRepo.GetAllAsync().Include(m => m.Unit);

        //        var totalRecords = await medicinesQuery.CountAsync();
        //        var skip = validFilter.PageNumber * validFilter.PageSize;
        //        var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
        //        int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        //        var pagedData = await medicinesQuery.Skip(skip)
        //                                 .Take(validFilter.PageSize)
        //                                 .ToListAsync();
        //        if (pagedData != null)
        //            return new PagedResponse<List<Product>>(pagedData, validFilter.PageNumber, validFilter.PageSize, totalRecords, roundedTotalPages);
        //        return new PagedResponse<List<Product>> { Data = null, IsSucceeded = false, Error = null };

        //    }
        //    catch (Exception e)
        //    {
        //        return new PagedResponse<List<Product>> { Data = null, IsSucceeded = false, Error = e.Message };

        //    }
        //}

        public async Task<Response<List<ProductWithUnitDTO>>> GetProductsWithUnitNames()
        {
            var products = await _unitOfWork.ProductRepo.GetProductsWithUnitNameAsync();
            if (products is null)
                return new Response<List<ProductWithUnitDTO>>(new List<ProductWithUnitDTO>());
            return new Response<List<ProductWithUnitDTO>>(_mapper.Map<List<ProductWithUnitDTO>>(products));
        }

        public void AddEventListenerToProduct(EventHandler<NotificationEventArgs> callback)
        {
            OnBla += callback;
        }

        public void sendProductNotification(object data)
        {
            OnBla.PublishForUsers(this, new List<string> { "7ad43e70-e562-4839-be02-9b85203ed5e5" }, EventsConfiguration.esmElevent, "desc", data);
        }
    }
}
