using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.DataAccess.Contexts;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace ShopList.DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFCategoryRepository : GenericRepository<Category>, ICategoryRepository
  {
    private readonly ShopListDbContext _context;
    public EFCategoryRepository(ShopListDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<List<Category>> GetCategoriesWithProducts()
    {
      return await _context.Categories.Include(c => c.Products).ToListAsync();
    }
  }
}