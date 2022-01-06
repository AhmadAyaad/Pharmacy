using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Domain.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> AddRangeOfProductsAsync(List<Product> medicines);
        Task<PagedResultDTO<Product>> GetProductsAsync(int pageSize, int pageIndex);
        Task<Product> GetProductWithUnitNameAsync(int productId);
        Task<List<Product>> GetProductsWithUnitNameAsync();
        Task<bool> IsProudctLocalCodeExistsAsync(Product product);
        Task<bool> IsProudctNationalCodeExistsAsync(Product product);
    }
}
