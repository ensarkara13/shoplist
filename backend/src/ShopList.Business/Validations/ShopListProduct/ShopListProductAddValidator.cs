using FluentValidation;
using ShopList.Entities.DTOs.ShopListProduct;

namespace ShopList.Business.Validations.ShopListProduct
{
  public class ShopListProductAddValidator : AbstractValidator<ShopListProductAddDto>
  {
    public ShopListProductAddValidator()
    {
      RuleFor(s => s.ProductId)
      .GreaterThan(0)
      .WithMessage("Geçersiz Ürün Id");

      RuleFor(s => s.ShopListId)
     .GreaterThan(0)
     .WithMessage("Geçersiz Alışveriş Listesi Id");
    }
  }
}