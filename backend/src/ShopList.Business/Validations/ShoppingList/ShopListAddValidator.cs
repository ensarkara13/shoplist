using FluentValidation;
using ShopList.Entities.DTOs.ShoppingList;

namespace ShopList.Business.Validations.ShoppingList
{
  public class ShopListAddValidator : AbstractValidator<ShopListAddDto>
  {
    public ShopListAddValidator()
    {
      RuleFor(s=>s.Name)
      .NotEmpty()
      .WithMessage("Alışveriş listesi adı alanı boş bırakılamaz.");

      RuleFor(s=>s.UserId)
      .GreaterThan(0)
      .WithMessage("Geçersiz Kullanıcı Id");
    }
  }
}