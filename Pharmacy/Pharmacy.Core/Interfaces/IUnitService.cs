using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IUnitService
    {
        Task<Unit> GetUnit(int id);
        Task<List<Unit>> GetUnits();
    }
}
