using ShopList.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ShopList.DataAccess.Repositories.Abstract
{
  public interface ICategoryRepository : IGenericRepository<Category>
  {
    Task<List<Category>> GetCategoriesWithProducts();
  }
}