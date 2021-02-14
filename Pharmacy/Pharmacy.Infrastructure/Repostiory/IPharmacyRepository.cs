using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public interface IPharmacyRepository
    {
        Task<IQueryable<Pharmacy.Infrastructure.Views.PharmacyProducts>> GetPharmacy(string pharmacyName);
    }
}
