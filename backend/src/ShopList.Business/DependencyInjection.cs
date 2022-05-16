using Microsoft.Extensions.DependencyInjection;
using ShopList.Business.Abstract;
using ShopList.Business.Concrete;
using FluentValidation.AspNetCore;
using ShopList.Business.Validations.User;

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

      services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserAddValidator>());

      return services;
    }
  }
}