using FluentValidation;
using ShopList.Entities.DTOs.User;

namespace ShopList.Business.Validations.User
{
  public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
  {
    public UserUpdateValidator()
    {
      
    }
  }
}