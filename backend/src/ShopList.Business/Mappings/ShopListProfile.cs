using System;
using AutoMapper;
using ShopList.Entities.Concrete;
using ShopList.Entities.DTOs.ShoppingList;

namespace ShopList.Business.Mappings
{
  public class ShopListProfile : Profile
  {
    public ShopListProfile()
    {
      // Add
      CreateMap<ShopListAddDto, ShoppingList>()
      .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

      // Update
      CreateMap<ShopListUpdateDto, ShoppingList>()
     .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now));

      // Get
      CreateMap<ShoppingList, ShopListGetDto>();
    }
  }
}