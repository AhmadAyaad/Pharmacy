using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Domain.IRepository
{
    public interface ISupplierOrderDetailsRepository : IRepository<SupplyOrderDetails>
    {
        Task<bool> IsExistingApprovalNumberAsync(int approvalNumber);
        Task<bool> IsExistingSupplyOrderNumberAsync(int supplyOrderNumber);
    }
}
