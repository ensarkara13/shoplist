using ShopList.DataAccess.Contexts;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.Concrete;

namespace ShopList.DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFCategoryRepository : GenericRepository<Category>, ICategoryRepository
  {
    public EFCategoryRepository(ShopListDbContext context) : base(context)
    {
    }
  }
}