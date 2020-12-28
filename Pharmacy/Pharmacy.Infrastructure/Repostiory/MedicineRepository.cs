using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public class MedicineRepository : IRepository<Medicine>
    {
        readonly DataContext _context;

        public MedicineRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Medicine medicine)
        {
            if (medicine != null)
            {
                await _context.Medicines.AddAsync(medicine);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Medicine medicine)
        {
            if (medicine != null)
            {
                var exisitingMedicine = await _context.Medicines.FindAsync(medicine.MedicineId);
                _context.Medicines.Remove(exisitingMedicine);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Medicine>> GetAll()
        {
            var medicines = await _context.Medicines.AsNoTracking().Include(m => m.Unit).ToListAsync();
            return medicines != null ? medicines : new List<Medicine>();
        }

        public async Task<Medicine> GetById(int id)
        {
            var medicine = await _context.Medicines.Include(m => m.Unit)
                                         .SingleOrDefaultAsync(m => m.MedicineId == id);
            return medicine != null ? medicine : new Medicine();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Medicine medicine)
        {
            if (medicine != null)
            {
                var medicineFromRepo = await _context.Medicines.FindAsync(medicine.MedicineId);
                medicineFromRepo.MedicineName = medicine.MedicineName;
                medicineFromRepo.SellingPrice = medicine.SellingPrice;
                medicineFromRepo.MedicineCode = medicine.MedicineCode;
                medicineFromRepo.ExpireDate = medicine.ExpireDate;
                medicineFromRepo.Supplier_Medicine_Pharmacies = medicine.Supplier_Medicine_Pharmacies;
                medicine.PatientTransactions = medicine.PatientTransactions;
                medicine.Unit = medicine.Unit;

                return true;
            }
            return false;
        }
    }
}
