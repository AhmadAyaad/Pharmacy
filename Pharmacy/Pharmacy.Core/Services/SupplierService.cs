using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> _supplierRepository;

        public SupplierService(IRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<bool> CreateSupplier(Supplier supplier)
        {
            var isCreated = await _supplierRepository.Create(supplier);
            try
            {
                if (isCreated)
                    await _supplierRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            try
            {
                var suppliers = await _supplierRepository.GetAll();
                if (suppliers != null)
                    return suppliers;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return new List<Supplier>();
        }
    }
}
