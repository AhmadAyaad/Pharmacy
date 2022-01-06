//using System;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using ZPharmacy.Core.Dtos;
//using ZPharmacy.Core.IServices;
//using ZPharmacy.Domain.Entities;
//using ZPharmacy.Infrastructure.UnitOfWork;

//namespace ZPharmacy.Core.Services
//{
//    public class ProductImportDetailsService : IProductImportDetailsService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public ProductImportDetailsService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public async Task<bool> CreateProductImport(CreateProductFromSupplierDto createProductFromSupplierDto)
//        {
//            try
//            {
//                if (createProductFromSupplierDto != null)
//                {
//                    var productImportDetails = new SupplierOrderDetails()
//                    {

//                        ImportOrderNumber = createProductFromSupplierDto.ImportOrderNumber,
//                        PurchaseFee = createProductFromSupplierDto.PurchaseFee,
//                        SupplyOrderNumber = createProductFromSupplierDto.SupplyOrderNumber,
//                        ApprovalNumber = createProductFromSupplierDto.ApprovalNumber
//                    };
//                    var isCreated = await _unitOfWork.SupplierOrderDetailsRepo.AddAsync(productImportDetails);
//                    if (isCreated)
//                        return true;
//                }
//            }
//            catch (Exception e)
//            {
//                Trace.WriteLine(e.Message);
//            }
//            return false;
//        }
//    }
//}
