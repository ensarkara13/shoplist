using FluentValidation;
using ShopList.Entities.DTOs.User;

namespace ShopList.Business.Validations.User
{
  public class UserAddValidator : AbstractValidator<UserAddDto>
  {
    public UserAddValidator()
    {
      RuleFor(u => u.FirstName)
      .NotEmpty()
      .WithMessage("İsim alanı boş bırakılamaz.")
      .Length(2, 20)
      .WithMessage("İsim en az 2, en fazla 20 karakterden oluşmalıdır.")
      .Matches("^[A-Za-zşğİüçöÖÜĞ]+$")
      .WithMessage("İsim sadece harflerden oluşmalıdır.");

      RuleFor(u => u.LastName)
      .NotEmpty()
      .WithMessage("Soyisim alanı boş bırakılamaz.")
      .Length(2, 20)
      .WithMessage("Soyisim en az 2, en fazla 20 karakterden oluşmalıdır.")
      .Matches("^[A-Za-zşğİüçöÖÜĞ]+$")
      .WithMessage("Soyisim sadece harflerden oluşmalıdır.");

      RuleFor(u => u.Email)
      .NotEmpty()
      .WithMessage("Email alanı boş bırakılamaz")
      .EmailAddress()
      .WithMessage("Geçerli bir email adresi giriniz.");

      RuleFor(u => u.Password)
      .NotEmpty()
      .WithMessage("Şifre alanı boş bırakılamaz.")
      .Length(8, 20)
      .WithMessage("Şifreniz en az 8, en fazla 20 karakterden oluşmalıdır.")
      .Matches("[A-Z]+")
      .WithMessage("Şifrenizde en az 1 adet büyük harf bulunmalıdır.")
      .Matches("[a-z]+")
      .WithMessage("Şifrenizde en az 1 adet küçük harf bulunmalıdır.")
      .Matches("[0-9]+")
      .WithMessage("Şifrenizde en az 1 adet rakam bulunmalıdır.");

      RuleFor(u => u.Role)
      .Matches("(^Admin$|^User$)")
      .WithMessage("Kullanıcı rolü 'Admin' ya da 'User' olabilir.");
    }
  }
}