using ShopList.Entities.Abstract;
using System.Collections.Generic;

namespace ShopList.Entities.Concrete
{
  public class Product : EntityBase
  {
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<ShopListProduct> ShopListProducts { get; set; }
  }
}