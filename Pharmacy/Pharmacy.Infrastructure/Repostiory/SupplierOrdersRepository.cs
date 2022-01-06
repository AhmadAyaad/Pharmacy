using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Infrastructure.Data;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class SupplierOrdersRepository : Repository<SupplyOrders>, ISupplierOrderRepository
    {
        public SupplierOrdersRepository(PharmacyDbContext context) : base(context)
        {
        }
        public Task<List<SupplyOrders>> GetSupplyOrdersAsync()
        {
            return _context.SupplyOrders.ToListAsync();
        }

        public Task<bool> IsExistingImportOrderNumberAsync(int importOrderNumber)
        {
            return _context.SupplyOrders.AnyAsync(so => so.ImportOrderNumber == importOrderNumber);
        }
    }
}
