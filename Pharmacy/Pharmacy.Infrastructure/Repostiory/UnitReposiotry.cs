using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;
using Pharmacy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public class UnitReposiotry : Repository<Unit>, IUnitRepository
    {
        public UnitReposiotry(DataContext context) : base(context)
        {
        }

        public async Task<int> GetUnitIdByName(object name)
        {
            var unit = await _context.Units.FirstOrDefaultAsync(unit => unit.UnitName == name);
            if (unit != null)
                return unit.UnitId;
            return 0;
        }
    }
}
