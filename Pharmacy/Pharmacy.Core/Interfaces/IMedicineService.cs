using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IMedicineService
    {
        Task<bool> CreateMedicine(Medicine medicine);
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<Medicine> GetMedicine(int id);
        Task<int> SaveChangesAsync();
    }
}
