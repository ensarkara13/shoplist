using ShopList.Entities.Abstract;
using System.Collections.Generic;

namespace ShopList.Entities.Concrete
{
  public class Category : EntityBase
  {
    public Category()
    {
      Products = new HashSet<Product>();
    }
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
  }
}