using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.IServices;
using ZPharmacy.Domain.Enums;
using ZPharmacy.Domain.View;
using ZPharmacy.Infrastructure.UnitOfWork;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.Services
{
    public class PharmacyService : IPharamcyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PharmacyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<LargePharmacyDTO>>> GetLargePharmacies()
        {
            var largePharamcies = await _unitOfWork.PharmacyRepo.GetLargePharmaciesAsync();
            if (largePharamcies is null)
                return new Response<List<LargePharmacyDTO>>(new List<LargePharmacyDTO>());
            return new Response<List<LargePharmacyDTO>>(_mapper.Map<List<LargePharmacyDTO>>(largePharamcies));
        }

        //public async Task<Domain.Entities.Pharmacy> GetPharmacyById(int id)
        //{
        //    var pharmacyFromDb = await _unitOfWork.PharmacyRepo.GetByIdAsync(id);
        //    return pharmacyFromDb != null ? pharmacyFromDb : null;
        //}

        //public async Task<IQueryable<ProductDetailQuantityView>> GetPharmacyProduct(int productId, int pharmacyId)
        //{
        //    return await _unitOfWork.PharmacyRepo.GetPharmacyProduct(productId, pharmacyId);
        //}

        public async Task<Response<PagedResultDTO<ProductQuantityView>>> GetExistingPharmacyProductsAsync(int pharmacyId, int pageIndex, int pageSize)
        {
            if (await _unitOfWork.PharmacyRepo.IsExistingPharmacyAsync(pharmacyId))
            {
                var pagedPharmacyProductsQuantites = await _unitOfWork.PharmacyRepo.GetExistingPharmacyProductsAsync(pharmacyId, pageIndex, pageSize);
                return new Response<PagedResultDTO<ProductQuantityView>>(pagedPharmacyProductsQuantites);
            }
            return new Response<PagedResultDTO<ProductQuantityView>>(null, ResponseStatus.BadRequest, "لايوجد صيدلية بهذا المتسلسل"); ;
        }

        public async Task<Response<ProductQuantityView>> GetPharmacyProductDetailsAsync(int pharmacyId, int productId)
        {
            if (await _unitOfWork.PharmacyRepo.IsExistingPharmacyAsync(pharmacyId))
            {
                var exisitngProduct = await _unitOfWork.ProductRepo.GetProductWithUnitNameAsync(productId);
                if (exisitngProduct != null)
                {
                    var productQuantityDetailViewModels = await _unitOfWork.ProductQuantityRepo.GetProductQuantityByProductIdAndPharmacyIdAsync(productId, pharmacyId);
                    var productQunatityView = _mapper.Map<ProductQuantityView>(exisitngProduct);
                    productQunatityView.TotalQuantity = productQuantityDetailViewModels.Sum(pqd => pqd.Quantity);
                    productQunatityView.ProductQuantityDetailViewModels = productQuantityDetailViewModels;
                    return new Response<ProductQuantityView>(productQunatityView);
                }
            }
            return new Response<ProductQuantityView>(null, ResponseStatus.BadRequest, "لايوجد صيدلية بهذا المسلسل");
        }
    }
}