using FluentValidation;
using ShopList.Entities.DTOs.Category;

namespace ShopList.Business.Validations.Category
{
  public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
  {
    public CategoryUpdateValidator()
    {
      RuleFor(c => c.Name)
      .NotEmpty()
      .WithMessage("Kategori adı alanı boş bırakılamaz.");
    }
  }
}