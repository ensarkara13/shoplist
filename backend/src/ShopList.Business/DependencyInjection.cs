using Microsoft.Extensions.DependencyInjection;
using ShopList.Business.Abstract;
using ShopList.Business.Concrete;

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

      return services;
    }
  }
}