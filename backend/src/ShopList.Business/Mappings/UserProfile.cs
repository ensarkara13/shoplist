using System;
using AutoMapper;
using ShopList.Entities.Concrete;
using ShopList.Entities.DTOs.User;

namespace ShopList.Business.Mappings
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      // Add
      CreateMap<UserAddDto, User>()
      .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.Now));

      // Update
      CreateMap<UserUpdateDto, User>()
      .ForMember(d => d.ModifiedAt, o => o.MapFrom(s => DateTime.Now));

      // Get
      CreateMap<User, UserGetDto>();
    }
  }
}