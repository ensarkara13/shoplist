using FluentValidation;
using ShopList.Entities.DTOs.Product;

namespace ShopList.Business.Validations.Product
{
  public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
  {
    public ProductUpdateValidator()
    {
      RuleFor(p => p.Name)
      .NotEmpty()
      .WithMessage("Ürün adı alanı boş bırakılamaz.");

      RuleFor(p => p.CategoryId)
      .GreaterThan(0)
      .WithMessage("Geçersiz Kategori Id");
    }
  }
}