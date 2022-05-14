using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopList.Entities.Concrete;

namespace ShopList.DataAccess.Contexts
{
  public class ShopListDbContext : DbContext, IShopListDbContext
  {
    public ShopListDbContext(DbContextOptions<ShopListDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingList> ShopLists { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
      .HasMany(u => u.ShoppingLists)
      .WithOne(u => u.User);

      modelBuilder.Entity<Category>()
      .HasMany(c => c.Products)
      .WithOne(c => c.Category)
      .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Product>()
      .HasMany(p => p.ShopListProducts)
      .WithOne(p => p.Product);

      modelBuilder.Entity<ShoppingList>()
      .HasMany(s => s.ShopListProducts)
      .WithOne(s => s.ShoppingList)
      .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<ShopListProduct>()
      .HasKey(s => new { s.ProductId, s.ShopListId });
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      return await base.SaveChangesAsync(cancellationToken);
    }
  }
}