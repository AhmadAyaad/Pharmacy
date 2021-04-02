using Pharmacy.Core.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IPharmacySupplyService
    {
       Task<bool> TransferProducts(int pharmacySupplierId, IEnumerable<PharamcyProductsTransferDTO> pharamcyProductsTransferDTOs);
    }
}
