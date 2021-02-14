using Pharmacy.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public class PharmacyRepository : Repository<Pharmacy.Domain.Entities.Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(PharmacyDbContext pharmacyDbContext) : base(pharmacyDbContext)
        {


        }

        public Task<IQueryable<Infrastructure.Views.PharmacyProducts>> GetPharmacy(string pharmacyName)
        {
            return Task.Run(() =>
             _context.PharmacyProducts.Where(pp => pp.PharmacyName == pharmacyName)
             );
        }
    }
}
