using AutoMapper;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.View;

namespace ZPharmacy.Core.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap().ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.UnitName));
            CreateMap<Product, ProductWithUnitDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => ConcatProductNameWithItsUnitName(src)));
            CreateMap<Product, ProductQuantityView>().ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.UnitName));
        }
        private string ConcatProductNameWithItsUnitName(Product product)
        {
            return $"{product.Name} {product.Unit.UnitName}";
        }
    }
}
