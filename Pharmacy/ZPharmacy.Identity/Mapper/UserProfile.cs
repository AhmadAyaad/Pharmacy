using AutoMapper;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Identity.DTOS;

namespace ZPharmacy.Identity.Mapper
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ReigsterUserDTO, User>();
        }
    }
}
