using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Domain.Entities.Products;
namespace LinkDev.Talabat.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dst => dst.Brand, O => O.MapFrom(src => src.Brand!.Name))
                .ForMember(dst => dst.Category, O => O.MapFrom(src => src.Category!.Name));
        }
    }
}
