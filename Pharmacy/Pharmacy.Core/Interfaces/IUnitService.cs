using Pharmacy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IUnitService
    {
        Task<Unit> GetUnit(int id);
        Task<List<Unit>> GetUnits();
        Task<int> GetUnitIdByName(object name);

    }
}
