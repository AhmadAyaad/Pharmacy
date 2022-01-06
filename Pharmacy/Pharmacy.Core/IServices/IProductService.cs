using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.EventHandler;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.IServices
{
    public interface IProductService
    {
        Task<Response> AddNewProductAsync(ProductDTO productDTO);
        Task<PagedResultDTO<ProductDTO>> GetPaginatedProductsAsync(PaginationFilter filter);
        Task<Response<List<ProductWithUnitDTO>>> GetProductsWithUnitNames();
        Task<Response<ProductDTO>> GetProductAsync(int id);
        //Task<Response> AddRangeAsync(List<Product> products);
        Task<Response> DeleteProductAsync(int productId);
        Task<Response> UpdateProductAsync(ProductDTO productDTO);
        Task<Response<List<ProductDTO>>> GetProductsAsync();
        void AddEventListenerToProduct(EventHandler<NotificationEventArgs> callback);
        void sendProductNotification(object data);

    }
    //class ProductQuantityViewModel
    //{
    //    public int Id { get; set; }
    //    public string LocalCode { get; set; }
    //    public string NationalCode { get; set; }
    //    public string Name { get; set; }
    //    public int ProductType { get; set; }
    //    public int UnitId { get; set; }
    //    public string UnitName { get; set; }
    //    public virtual ExpireDateQuantityViewModel ExpireDateQuantityViewModel { get; set; }
    //}
    //class ExpireDateQuantityViewModel
    //{
    //    public DateTime ExpireDate { get; set; }
    //    public int Quantity { get; set; }
    //}
}
