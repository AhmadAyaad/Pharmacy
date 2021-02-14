using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Enums;
using Pharmacy.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;


        public MedicineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddRangOfMedicines(List<Medicine> medicines)
        {
            try
            {
                await _unitOfWork.SpecificMedicineRepository.AddRangeOfMedicines(medicines);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return false;
        }


        public async Task<bool> CreateMedicine(CreateMedicineDto createMedicineDto)
        {
            Enum.TryParse(createMedicineDto.ProductType, out ProductType productType);
            var medicine = new Medicine
            {
                MedicineCode = createMedicineDto.MedicineCode,
                NationalCode = createMedicineDto.NationalCode,
                ProductType = productType,
                UnitId = createMedicineDto.UnitId,
                MedicineName = createMedicineDto.MedicineName,
                SellingPrice = createMedicineDto.SellingPrice

            };

            var isCreated = await _unitOfWork.MedicineRepository.Create(medicine);
            try
            {
                if (isCreated)
                    await _unitOfWork.SaveChangesAsync();
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
                var medicine = await _unitOfWork.MedicineRepository.GetById(id);
                if (medicine != null)
                    return medicine;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return new Medicine();
        }

        public async Task<List<Medicine>> GetMedicines()
        {
            try
            {
                var medicines = await _unitOfWork.MedicineRepository.GetAll().ToListAsync();
                if (medicines != null)
                    return medicines;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return new List<Medicine>();
        }

        public async Task<List<Medicine>> GetMedicinesWithUnitNames()
        {
            try
            {
                var mappedMedicines = new List<Medicine>();
                var medicines = await _unitOfWork.MedicineRepository.GetAll().Include(m => m.Unit).ToListAsync();
                if (medicines != null)
                {
                    foreach (var item in medicines)
                    {
                        mappedMedicines.Add(
                            new Medicine() { MedicineName = $"{item.MedicineName} {item.Unit.UnitName}"  , MedicineId = item.MedicineId});
                    };
                }
                return mappedMedicines;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return new List<Medicine>();
        }







    }
}
