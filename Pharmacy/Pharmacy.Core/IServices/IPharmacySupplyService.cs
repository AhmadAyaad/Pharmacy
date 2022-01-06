using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.IServices
{
    public interface IPharmacySupplyService
    {
        Response<Task<bool>> TransferProducts(int pharmacySupplierId, IEnumerable<PharamcyProductsTransferDTO> pharamcyProductsTransferDTOs);
    }
}
