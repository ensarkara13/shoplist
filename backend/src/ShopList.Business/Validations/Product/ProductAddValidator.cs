using FluentValidation;
using ShopList.Entities.DTOs.Product;

namespace ShopList.Business.Validations.Product
{
  public class ProductAddValidator : AbstractValidator<ProductAddDto>
  {
    public ProductAddValidator()
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