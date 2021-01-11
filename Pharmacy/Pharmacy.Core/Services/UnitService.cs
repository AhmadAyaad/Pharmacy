using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetUnitIdByName(object name)
        {
            return await _unitOfWork.SpecficUnitRepository.GetUnitIdByName(name);
        }

        public async Task<Unit> GetUnit(int id)
        {
            try
            {
                var unit = await _unitOfWork.UnitRepository.GetById(id);
                if (unit != null)
                    return unit;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return new Unit();
        }

        public async Task<List<Unit>> GetUnits()
        {
            try
            {
                var units = await _unitOfWork.UnitRepository.GetAll().ToListAsync();
                if (units != null)
                    return units;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return new List<Unit>();
        }
    }
}
