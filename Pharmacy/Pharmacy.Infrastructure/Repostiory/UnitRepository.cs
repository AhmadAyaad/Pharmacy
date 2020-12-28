using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public class UnitRepository : IRepository<Unit>
    {
        private readonly DataContext _context;

        public UnitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Unit unit)
        {
            if (unit != null)
            {
                if (!_context.Units.Any(u => u.UnitName == unit.UnitName))
                {
                    await _context.Units.AddAsync(unit);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Delete(Unit unit)
        {
            if (unit != null)
            {
                var exisitingUnit = await _context.Units.FindAsync(unit.UnitId);
                _context.Units.Remove(exisitingUnit);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Unit>> GetAll()
        {
            var units = await _context.Units.AsNoTracking().ToListAsync();
            return units != null ? units : new List<Unit>();
        }

        public async Task<Unit> GetById(int id)
        {
            var unit = await _context.Units.AsNoTracking().SingleOrDefaultAsync(u => u.UnitId == id);
            return unit != null ? unit : new Unit();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Unit unit)
        {
            if (unit != null)
            {
                var unitFromRepo = await _context.Units.FindAsync(unit.UnitId);
                unitFromRepo.UnitName = unit.UnitName;

                return true;
            }
            return false;
        }
    }
}
