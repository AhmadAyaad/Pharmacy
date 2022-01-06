using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Domain.IRepository
{
    public interface ISupplierOrderRepository : IRepository<SupplyOrders>
    {
        Task<List<SupplyOrders>> GetSupplyOrdersAsync();
        Task<bool> IsExistingImportOrderNumberAsync(int importOrderNumber);
    }
}
