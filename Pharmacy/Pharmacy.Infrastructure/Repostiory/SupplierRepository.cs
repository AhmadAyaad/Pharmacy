using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Infrastructure.Data;
using ZPharmacy.Infrastructure.Extensions;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(PharmacyDbContext context) : base(context)
        {
        }

        public Task<PagedResultDTO<Supplier>> GetPagedSuppliersAsync(int pageIndex, int pageSize)
        {
            return _context.Suppliers.GetPagedAsync(pageIndex, pageSize);
        }

        public Task<bool> IsSupplierNameExistsAsync(Supplier supplier)
        {
            return _context.Suppliers.AnyAsync(s => s.Name == supplier.Name);
        }
        public Task<bool> IsSupplierPhoneExistsAsync(Supplier supplier)
        {
            return _context.Suppliers.AnyAsync(s => s.Phone == supplier.Phone);
        }
    }
}
