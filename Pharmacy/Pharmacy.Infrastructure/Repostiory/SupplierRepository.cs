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
    public class SupplierRepository : IRepository<Supplier>
    {
        readonly DataContext _context;

        public SupplierRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Supplier supplier)
        {
            if (supplier != null)
            {
                await _context.Suppliers.AddAsync(supplier);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Supplier supplier)
        {
            if (supplier != null)
            {
                var exisitingSupplier = await _context.Suppliers.FindAsync(supplier.SupplierId);
                _context.Suppliers.Remove(exisitingSupplier);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var suppliers = await _context.Suppliers.AsNoTracking().ToListAsync();
            return suppliers != null ? suppliers : new List<Supplier>();
        }

        public async Task<Supplier> GetById(int id)
        {
            var supplier = await _context.Suppliers.AsNoTracking().SingleOrDefaultAsync(s => s.SupplierId == id);
            return supplier != null ? supplier : new Supplier();
        }

        public async Task<bool> Update(Supplier supplier)
        {
            if (supplier != null)
            {
                var supplierFromRepo = await _context.Suppliers.FindAsync(supplier.SupplierId);
                supplierFromRepo.SupplierName = supplier.SupplierName;
                supplierFromRepo.Phone = supplier.Phone;
                supplierFromRepo.Address = supplier.Address;
                supplierFromRepo.Supplier_Medicine_Pharmacies = supplier.Supplier_Medicine_Pharmacies;

                return true;
            }
            return false;
        }



    }
}
