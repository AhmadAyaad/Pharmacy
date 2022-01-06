using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.IServices
{
    public interface IUnitService
    {
        //Response<Task<Unit>> GetUnit(int id);
        Task<Response<List<UnitDTO>>> GetUnits();
        //Response<Task<int>> GetUnitIdByName(object name);

    }
}
