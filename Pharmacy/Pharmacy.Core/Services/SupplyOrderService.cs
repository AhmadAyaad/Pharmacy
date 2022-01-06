using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.IServices;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Infrastructure.UnitOfWork;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.Services
{
    public class SupplyOrderService : ISupplyOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplyOrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<SupplyOrderDTO>>> GetSupplyOrdersAsync()
        {
            var supplyOrders = await _unitOfWork.SupplierOrderRepo.GetSupplyOrdersAsync();
            return new Response<List<SupplyOrderDTO>>(_mapper.Map<List<SupplyOrderDTO>>(supplyOrders));
        }

        public async Task<Response> ReceiveSupplyOrderAsync(SupplyOrderDTO supplyOrderDTO)
        {
            if (await _unitOfWork.SupplierOrderRepo.IsExistingImportOrderNumberAsync(supplyOrderDTO.ImportOrderNumber))
                return new Response(ResponseStatus.Failed, "رقم أمر توريد مكرر");
            foreach (var supplyOrderItem in supplyOrderDTO.SupplyOrdersDetailsDTO)
            {
                if (await _unitOfWork.SupplierOrderDetailsRepo.IsExistingApprovalNumberAsync(supplyOrderItem.ApprovalNumber))
                    return new Response(ResponseStatus.Failed, "رقم إذن إمداد مكرر");
                if (await _unitOfWork.SupplierOrderDetailsRepo.IsExistingSupplyOrderNumberAsync(supplyOrderItem.SupplyOrderNumber))
                    return new Response(ResponseStatus.Failed, "رقم امر إمداد مكرر");
            }
            var supplyOrder = _mapper.Map<SupplyOrders>(supplyOrderDTO);

            await _unitOfWork.SupplierOrderRepo.AddAsync(supplyOrder);
            var productsQuantities = await _unitOfWork.ProductQuantityRepo.GetAllAsync();
            //add
            var exisitngProductsWithNewExpireDate = supplyOrder.SupplyOrdersDetails
                                                               .Where(x => productsQuantities.All(y => y.ExpireDate != x.ExpireDate))
                                                               .Select(supplyOrdersDetails => new ProductQuantity
                                                               {
                                                                   ExpireDate = supplyOrdersDetails.ExpireDate,
                                                                   PharmacyId = supplyOrdersDetails.PharmacyId,
                                                                   ProductId = supplyOrdersDetails.ProductId,
                                                                   Price = supplyOrdersDetails.Price,
                                                                   TotalProductQuantity = supplyOrdersDetails.Quantity
                                                               }).ToList();
            _unitOfWork.ProductQuantityRepo.AddRangeAsync(exisitngProductsWithNewExpireDate);
            //update
            var exisitngProductsWithSameExpireDate = supplyOrder.SupplyOrdersDetails
                                                                .Where(x => productsQuantities.Any(y => y.ExpireDate == x.ExpireDate))
                                                                .ToList();
            foreach (var exisitngProductWithNewExpireDate in exisitngProductsWithSameExpireDate)
            {
                var exisitingProduct = await _unitOfWork.ProductQuantityRepo.GetProductByExpireDateAndProductId(exisitngProductWithNewExpireDate.ExpireDate, exisitngProductWithNewExpireDate.ProductId);
                exisitingProduct.ExpireDate = exisitngProductWithNewExpireDate.ExpireDate;
                exisitingProduct.TotalProductQuantity += exisitngProductWithNewExpireDate.Quantity;
            }
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }
    }
}
