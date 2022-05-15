using ShopList.DataAccess.Contexts;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.Concrete;

namespace ShopList.DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFShopListProductRepository : GenericRepository<ShopListProduct>, IShopListProductRepository
  {
    public EFShopListProductRepository(ShopListDbContext context) : base(context)
    {
    }
  }
}