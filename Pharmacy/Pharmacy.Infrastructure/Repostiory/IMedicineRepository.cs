using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public interface IMedicineRepository
    {
        Task<bool> AddRangeOfMedicines(List<Medicine> medicines); 
    }
}
