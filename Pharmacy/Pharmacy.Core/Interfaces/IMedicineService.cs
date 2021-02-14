using Pharmacy.Core.Dtos;
using Pharmacy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IMedicineService
    {
        Task<bool> CreateMedicine(CreateMedicineDto createMedicineDto);
        Task<List<Medicine>> GetMedicines();
        Task<List<Medicine>> GetMedicinesWithUnitNames();
        Task<Medicine> GetMedicine(int id);
        Task<bool> AddRangOfMedicines(List<Medicine> medicines);

    }
}
