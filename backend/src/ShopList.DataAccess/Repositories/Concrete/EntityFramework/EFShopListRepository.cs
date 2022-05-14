using ShopList.DataAccess.Contexts;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.Concrete;

namespace ShopList.DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFShopListRepository : GenericRepository<ShoppingList>, IShopListRepository
  {
    public EFShopListRepository(ShopListDbContext context) : base(context)
    {
    }
  }
}