using ShopList.DataAccess.Contexts;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.Concrete;

namespace ShopList.DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFProductRepository : GenericRepository<Product>, IProductRepository
  {
    public EFProductRepository(ShopListDbContext context) : base(context)
    {
    }
  }
}