using System;
using AutoMapper;
using ShopList.Entities.Concrete;
using ShopList.Entities.DTOs.Product;

namespace ShopList.Business.Mappings
{
  public class ProductProfile : Profile
  {
    public ProductProfile()
    {
      // Add
      CreateMap<ProductAddDto, Product>()
      .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

      // Update
      CreateMap<ProductUpdateDto, Product>()
     .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now));

      // Get
      CreateMap<Product, ProductGetDto>()
      .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToLongDateString()))
      .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt.ToLongDateString()));
    }
  }
}