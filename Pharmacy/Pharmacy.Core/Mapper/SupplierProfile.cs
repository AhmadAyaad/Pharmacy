using AutoMapper;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Core.Mapper
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierDTO, Supplier>().ReverseMap();
        }
    }
}
