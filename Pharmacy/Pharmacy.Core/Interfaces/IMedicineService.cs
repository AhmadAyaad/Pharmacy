using Pharmacy.Core.Dtos;
using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IMedicineService
    {
        Task<bool> CreateMedicine(CreateMedicineDto createMedicineDto);
        Task<List<Medicine>> GetMedicines();
        Task<Medicine> GetMedicine(int id);
        Task<bool> AddRangOfMedicines(List<Medicine> medicines);

    }
}
