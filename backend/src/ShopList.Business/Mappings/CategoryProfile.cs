using System;
using AutoMapper;
using ShopList.Entities.Concrete;
using ShopList.Entities.DTOs.Category;

namespace ShopList.Business.Mappings
{
  public class CategoryProfile : Profile
  {
    public CategoryProfile()
    {
      // Add
      CreateMap<CategoryAddDto, Category>()
      .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

      // Update
      CreateMap<CategoryUpdateDto, Category>()
     .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now));

      // Get
      CreateMap<Category, CategoryGetDto>()
      .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToLongDateString()))
      .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt.ToLongDateString()));
    }
  }
}