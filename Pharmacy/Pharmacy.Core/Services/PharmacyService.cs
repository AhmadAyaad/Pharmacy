using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class PharmacyService : IPharamcyService
    {
        readonly IRepository<Domain.Entities.Pharmacy> _pharmacyRepository;

        public PharmacyService(IRepository<Pharmacy.Domain.Entities.Pharmacy> pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }
        public IEnumerable<Domain.Entities.Pharmacy> GetParentPharamices()
        {
           var largePharamcies = _pharmacyRepository.Find(p => p.PharmacyType.PharmacyTypeEnum == Domain.Enums.PharmacyTypeEnum.Large);
            if (largePharamcies != null)
                return largePharamcies;
            return new List<Pharmacy.Domain.Entities.Pharmacy>();

        }
    }
}
