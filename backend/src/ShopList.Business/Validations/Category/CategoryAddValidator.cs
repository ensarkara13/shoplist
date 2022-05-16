using FluentValidation;
using ShopList.Entities.DTOs.Category;

namespace ShopList.Business.Validations.Category
{
  public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
  {
    public CategoryAddValidator()
    {
      RuleFor(c => c.Name)
      .NotEmpty()
      .WithMessage("Kategori adı alanı boş bırakılamaz.");
    }
  }
}