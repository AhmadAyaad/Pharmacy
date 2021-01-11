using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class SupplierService : ISupplierService
    {
        //private readonly IRepository<Supplier> _supplierRepository;
        //private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IUnitOfWork _unitOfWork;


        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateSupplier(CreateSupplierDto createSupplierDto)
        {
            var supplier = new Supplier
            {
                SupplierName = createSupplierDto.SupplierName,
                Address = createSupplierDto.Address,
                Phone = createSupplierDto.Phone
            };
            var isCreated = await _unitOfWork.SupplierRepository.Create(supplier);
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

        public async Task<List<Supplier>> GetSuppliers()
        {
            try
            {
                var suppliers = await _unitOfWork.SupplierRepository.GetAll().ToListAsync();
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
