using Pharmacy.Domain.Entities;
using Pharmacy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public class MedicineRepoistory : Repository<Medicine>, IMedicineRepository
    {
        public MedicineRepoistory(PharmacyDbContext context) : base(context)
        {

        }
        public async Task<bool> AddRangeOfMedicines(List<Medicine> medicines)
        {
            try
            {
                await _context.Medicines.AddRangeAsync(medicines);
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return false;
        }
    }
}
