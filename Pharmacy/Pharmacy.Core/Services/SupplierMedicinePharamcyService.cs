using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pharmacy.Core.Services
{
    public class SupplierMedicinePharamcyService : ISupplierMedicinePharamcyService
    {
        readonly IRepository<SupplierProductsTransfer> _supplierMedicinePharmacyRepository;

        public SupplierMedicinePharamcyService(IRepository<SupplierProductsTransfer>
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
                    var supplier_medicine_phamracy = new SupplierProductsTransfer()
                    {
                        MedicineId = createProductFromSupplierDto.ProductId,
                        PharmacyId = createProductFromSupplierDto.PharmacyId,
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
                return false;

            }
            return false;
        }
    }
}
