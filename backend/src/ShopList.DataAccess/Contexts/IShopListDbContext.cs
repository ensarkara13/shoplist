using Microsoft.EntityFrameworkCore;
using ShopList.Entities.Concrete;
using System.Threading.Tasks;
using System.Threading;


namespace ShopList.DataAccess.Contexts
{
  public interface IShopListDbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingList> ShopLists { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  }
}