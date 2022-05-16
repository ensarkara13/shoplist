using FluentValidation;
using ShopList.Entities.DTOs.ShoppingList;

namespace ShopList.Business.Validations.ShoppingList
{
  public class ShopListUpdateValidator : AbstractValidator<ShopListUpdateDto>
  {
    public ShopListUpdateValidator()
    {
      RuleFor(s => s.Name)
        .NotEmpty()
        .WithMessage("Alışveriş listesi adı alanı boş bırakılamaz.");
    }
  }
}