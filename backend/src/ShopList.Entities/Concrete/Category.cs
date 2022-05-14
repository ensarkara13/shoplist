using ShopList.Entities.Abstract;
using System.Collections.Generic;

namespace ShopList.Entities.Concrete
{
  public class Category : EntityBase
  {
    public string Name { get; set; }
    public string ModifiedBy { get; set; }

    public ICollection<Product> Products { get; set; }
  }
}