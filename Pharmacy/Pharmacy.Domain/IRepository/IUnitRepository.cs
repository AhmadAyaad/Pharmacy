using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Domain.IRepository
{
    public interface IUnitRepository : IRepository<Unit>
    {
        Task<int> GetUnitIdByNameAsync(object name);

    }
}
