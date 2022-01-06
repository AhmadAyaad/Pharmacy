using AutoMapper;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Core.Mapper
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDTO>();
        }

    }
}
