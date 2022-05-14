using ShopList.DataAccess.Contexts;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.Concrete;

namespace ShopList.DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFUserRepository : GenericRepository<User>, IUserRepository
  {
    public EFUserRepository(ShopListDbContext context) : base(context)
    {
    }
  }
}