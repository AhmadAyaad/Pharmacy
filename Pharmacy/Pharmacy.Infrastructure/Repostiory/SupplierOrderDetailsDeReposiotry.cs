using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Infrastructure.Data;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class SupplierOrderDetailsDeReposiotry : Repository<SupplyOrderDetails>, ISupplierOrderDetailsRepository
    {
        public SupplierOrderDetailsDeReposiotry(PharmacyDbContext context) : base(context)
        {
        }
        public Task<bool> IsExistingApprovalNumberAsync(int approvalNumber)
        {
            return _context.SupplyOrderDetails.AnyAsync(sod => sod.ApprovalNumber == approvalNumber);
        }
        public Task<bool> IsExistingSupplyOrderNumberAsync(int supplyOrderNumber)
        {
            return _context.SupplyOrderDetails.AnyAsync(sod => sod.SupplyOrderNumber == supplyOrderNumber);
        }
    }
}
