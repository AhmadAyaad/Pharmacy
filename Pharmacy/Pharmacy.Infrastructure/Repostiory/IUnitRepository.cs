using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public interface IUnitRepository
    {
        Task<int> GetUnitIdByName(object name);
    }
}
