using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Infrastructure.Data;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class UnitReposiotry : Repository<Unit>, IUnitRepository
    {
        public UnitReposiotry(PharmacyDbContext context) : base(context)
        {
        }

        public async Task<int> GetUnitIdByNameAsync(object name)
        {
            var unit = await _context.Units.FirstOrDefaultAsync(unit => unit.UnitName == (string)name);
            if (unit != null)
                return unit.Id;
            return 0;
        }
    }
}
