using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.View;
using Pharmacy.Infrastructure.UnitOfWork;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class PharmacyService : IPharamcyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PharmacyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Domain.Entities.Pharmacy> GetParentPharamices()
        {
            var largePharamcies = _unitOfWork.PharmacyRepository
                                  .Find(p => p.PharmacyType.PharmacyTypeEnum == Domain.Enums.PharmacyTypeEnum.Large);
            if (largePharamcies != null)
                return largePharamcies;
            return new List<Pharmacy.Domain.Entities.Pharmacy>();
        }

        public async Task<Domain.Entities.Pharmacy> GetPharmacyById(int id)
        {
            var pharmacyFromDb = await _unitOfWork.PharmacyRepository.GetById(id);
            return pharmacyFromDb != null ? pharmacyFromDb : null;
        }

        public async Task<IQueryable<ProductDetailQuantityView>> GetPharmacyProduct(int productId, int pharmacyId)
        {
            return await _unitOfWork.SpecficPharmacyRepository.GetPharmacyProduct(productId, pharmacyId);
        }

        public Task<IQueryable<ProductQuantityView>> GetPharmacyProducts(int pharmacyId)
        {
            return _unitOfWork.SpecficPharmacyRepository.GetPharmacyProducts(pharmacyId);
        }
    }
}