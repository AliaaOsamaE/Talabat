using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Domain.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace LinkDev.Talabat.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public IConfiguration Configuration { get; set; }
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dst => dst.Brand, O => O.MapFrom(src => src.Brand!.Name))
                .ForMember(dst => dst.Category, O => O.MapFrom(src => src.Category!.Name))
                 //.ForMember(dst => dst.PictureUrl, O => O.MapFrom(src => $"{""}{src.PictureUrl}"));
                 .ForMember(dst => dst.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductCategory, CategoryDto>();
        }
    }
}
