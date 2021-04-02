using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Infrastructure.UnitOfWork;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class PharmacySupplyService : IPharmacySupplyService
    {
        private readonly UnitOfWork _unitOfWork;

        public PharmacySupplyService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> TransferProducts(int pharmacySupplierId, IEnumerable<PharamcyProductsTransferDTO> pharamcyProductsTransferDTOs)
        {
            throw new System.NotImplementedException();
        }
    }
}