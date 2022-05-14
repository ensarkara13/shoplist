using ShopList.Entities.Abstract;
using System.Collections.Generic;


namespace ShopList.Entities.Concrete
{
  public class ShoppingList : EntityBase
  {
    public string Name { get; set; }
    public bool IsShopping { get; set; }
    public bool IsFinished { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<ShopListProduct> ShopListProducts { get; set; }
  }
}