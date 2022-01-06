using AutoMapper;
using System.Linq;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Core.Mapper
{
    public class SupplyOrderProfile : Profile
    {
        public SupplyOrderProfile()
        {
            CreateMap<SupplyOrderDTO, SupplyOrders>()
                    .ForMember(dest => dest.SupplyOrdersDetails, opt => opt.MapFrom(src => src.SupplyOrdersDetailsDTO.Select(sod => new SupplyOrderDetails
                    {
                        ApprovalNumber = sod.ApprovalNumber,
                        BatchNumber = sod.BatchNumber,
                        ExpireDate = sod.ExpireDate,
                        PharmacyId = sod.PharmacyId,
                        Price = sod.Price,
                        PurchaseFee = sod.PurchaseFee,
                        Quantity = sod.Quantity,
                        SupplyOrderNumber = sod.SupplyOrderNumber,
                        ProductId = sod.ProductId,
                        SupplierId = sod.SupplierId
                    })));
            CreateMap<SupplyOrders, SupplyOrderDTO>().ForMember(dest => dest.SupplyOrdersDetailsDTO, opt => opt.MapFrom(src => src.SupplyOrdersDetails.Select(sod => new SupplyOrderDetailsDTO
            {
                ApprovalNumber = sod.ApprovalNumber,
                BatchNumber = sod.BatchNumber,
                ExpireDate = sod.ExpireDate,
                PharmacyId = sod.PharmacyId,
                Price = sod.Price,
                PurchaseFee = sod.PurchaseFee,
                Quantity = sod.Quantity,
                SupplyOrderNumber = sod.SupplyOrderNumber,
                ProductId = sod.ProductId,
                SupplierId = sod.SupplierId

            })));
        }
    }
}
