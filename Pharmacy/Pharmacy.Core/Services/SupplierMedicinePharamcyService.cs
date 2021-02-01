using Pharmacy.Core.Dtos;
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
    public class SupplierMedicinePharamcyService : ISupplierMedicinePharamcyService
    {
        readonly IRepository<Supplier_Medicine_Pharmacy> _supplierMedicinePharmacyRepository;

        public SupplierMedicinePharamcyService(IRepository<Supplier_Medicine_Pharmacy>
                                               supplierMedicinePharmacyRepository)
        {
            _supplierMedicinePharmacyRepository = supplierMedicinePharmacyRepository;
        }
        public async Task<bool> CreateNewProductTransfer(CreateProductFromSupplierDto createProductFromSupplierDto)
        {
            try
            {
                if (createProductFromSupplierDto != null)
                {
                    var supplier_medicine_phamracy = new Supplier_Medicine_Pharmacy()
                    {
                        MedicineId = createProductFromSupplierDto.ProductId,
                        PharmacyId = createProductFromSupplierDto.PharmacyId,
                        SupplierId = createProductFromSupplierDto.SupplierId,
                        Price = createProductFromSupplierDto.Price,
                        Quantity = createProductFromSupplierDto.Quantity
                    };
                    var isCreated = await _supplierMedicinePharmacyRepository
                                          .Create(supplier_medicine_phamracy);
                    if (isCreated)
                        return true;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return false;
        }
    }
}
