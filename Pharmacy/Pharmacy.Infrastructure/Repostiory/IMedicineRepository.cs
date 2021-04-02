using Pharmacy.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public interface IMedicineRepository
    {
        Task<bool> AddRangeOfMedicines(List<Medicine> medicines);
    }
}
