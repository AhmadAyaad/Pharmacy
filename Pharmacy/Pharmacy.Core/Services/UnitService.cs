using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> _unitRepository;

        public UnitService(IRepository<Unit> unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<Unit> GetUnit(int id)
        {
            try
            {
                var unit = await _unitRepository.GetById(id);
                if (unit != null)
                    return unit;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return new Unit();
        }
    }
}
