using AutoMapper;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Core.Mapper
{
    class PharmacyProfile : Profile
    {
        public PharmacyProfile()
        {
            CreateMap<Pharmacy, LargePharmacyDTO>();
        }
    }
}
