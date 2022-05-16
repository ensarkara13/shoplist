using System;
using AutoMapper;
using ShopList.Entities.Concrete;
using ShopList.Entities.DTOs.ShopListProduct;

namespace ShopList.Business.Mappings
{
  public class ShopListProductProfile : Profile
  {
    public ShopListProductProfile()
    {
      // Add
      CreateMap<ShopListProductAddDto, ShopListProduct>()
      .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

      // Update
      CreateMap<ShopListProductUpdateDto, ShopListProduct>()
     .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now));

      // Get
      CreateMap<ShopListProduct, ShopListProductGetDto>();
    }
  }
}