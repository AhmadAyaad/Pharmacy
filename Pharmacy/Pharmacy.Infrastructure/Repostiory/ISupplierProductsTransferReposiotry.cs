using Pharmacy.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public interface ISupplierProductsTransferReposiotry
    {
        Task<bool> AddRangeAsync(List<SupplierProductsTransfer> supplierProductsTransfers);
    }
}
