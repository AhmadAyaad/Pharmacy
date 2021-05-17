using Pharmacy.Core.Dtos;
using Pharmacy.Core.Pagniation;
using Pharmacy.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IMedicineService
    {
        Task<bool> CreateMedicine(CreateMedicineDto createMedicineDto);
        Task<PagedResponse<List<Medicine>>> GetMedicines(PaginationFilter filter);
        Task<List<Medicine>> GetMedicinesWithUnitNames();
        Task<Medicine> GetMedicine(int id);
        Task<bool> AddRangOfMedicines(List<Medicine> medicines);
        Task<bool> DeleteMedicine(int medicineId);

    }
}
