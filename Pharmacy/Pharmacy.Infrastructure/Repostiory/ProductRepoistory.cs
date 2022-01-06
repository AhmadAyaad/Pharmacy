using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ZPharmacy.Domain;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Infrastructure.Data;
using ZPharmacy.Infrastructure.Extensions;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class ProductRepoistory : Repository<Product>, IProductRepository
    {
        public ProductRepoistory(PharmacyDbContext context) : base(context)
        {
        }
        public async Task<bool> AddRangeOfProductsAsync(List<Product> medicines)
        {
            try
            {
                await _context.Products.AddRangeAsync(medicines);
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return false;
        }

        public Task<PagedResultDTO<Product>> GetProductsAsync(int pageSize, int pageIndex)
        {
            return _context.Products.Include(p => p.Unit).GetPagedAsync(pageIndex, pageSize);
        }

        public Task<List<Product>> GetProductsWithUnitNameAsync()
        {
            return _context.Products.Include(p => p.Unit).ToListAsync();
        }

        public Task<Product> GetProductWithUnitNameAsync(int productId)
        {
            return _context.Products.Include(p => p.Unit).SingleOrDefaultAsync(p => p.Id == productId);
        }
        public Task<bool> IsProudctLocalCodeExistsAsync(Product product)
        {
            return _context.Products.AnyAsync(p => p.LocalCode == product.LocalCode);
        }
        public Task<bool> IsProudctNationalCodeExistsAsync(Product product)
        {
            return _context.Products.AnyAsync(p => p.NationalCode == product.NationalCode);
        }
    }
}
