using Pharmacy.Core.Interfaces;
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

        public async Task<IQueryable<Infrastructure.Views.PharmacyProducts>> GetPharmacy(string pharmacyName)
        {
            var pharamcyProdcuts = await _unitOfWork.SpecficPharmacyRepository
                                        .GetPharmacy(pharmacyName: pharmacyName);
            return pharamcyProdcuts;
        }




    }
}
