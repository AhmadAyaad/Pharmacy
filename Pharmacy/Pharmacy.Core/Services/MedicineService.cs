﻿using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IRepository<Medicine> _medicineRepository;

        public MedicineService(IRepository<Medicine> medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public async Task<bool> CreateMedicine(Medicine medicine)
        {
            var isCreated = await _medicineRepository.Create(medicine);
            try
            {
                if (isCreated)
                    await _medicineRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                Trace.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<Medicine> GetMedicine(int id)
        {
            try
            {
                var medicine = await _medicineRepository.GetById(id);
                if (medicine != null)
                    return medicine;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return new Medicine();
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            try
            {
                var medicines = await _medicineRepository.GetAll();
                if (medicines != null)
                    return medicines;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return new List<Medicine>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _medicineRepository.SaveChangesAsync();
        }
    }
}
