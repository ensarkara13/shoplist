using Microsoft.Extensions.DependencyInjection;
using ShopList.Business.Abstract;
using ShopList.Business.Concrete;
using FluentValidation.AspNetCore;
using ShopList.Business.Validations.User;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace ShopList.Business
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {

      services.AddScoped<IUserService, UserManager>();
      services.AddScoped<ICategoryService, CategoryManager>();
      services.AddScoped<IProductService, ProductManager>();
      services.AddScoped<IShopListService, ShopListManager>();
      services.AddScoped<IShopListProductService, ShopListProductManager>();

      services.AddScoped<IPasswordHasher<string>, PasswordHasher<string>>();

      services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      return services;
    }
  }
}