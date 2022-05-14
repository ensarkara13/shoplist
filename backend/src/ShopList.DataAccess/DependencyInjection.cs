using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopList.DataAccess.Contexts;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.DataAccess.Repositories.Concrete.EntityFramework;

namespace ShopList.DataAccess
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ShopListDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ShopListDB")));

      services.AddScoped<IShopListDbContext, ShopListDbContext>();

      services.AddScoped<ICategoryRepository, EFCategoryRepository>();
      services.AddScoped<IProductRepository, EFProductRepository>();
      services.AddScoped<IShopListRepository, EFShopListRepository>();
      services.AddScoped<IUserRepository, EFUserRepository>();

      return services;
    }
  }
}