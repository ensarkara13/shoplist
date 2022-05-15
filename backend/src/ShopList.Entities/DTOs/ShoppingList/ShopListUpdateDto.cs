using System;
using System.Collections.Generic;
using ShopList.Entities.Concrete;

namespace ShopList.Entities.DTOs.ShoppingList
{
  public class ShopListUpdateDto
  {
    public string Name { get; set; }
    public bool IsShopping { get; set; }
    public bool IsFinished { get; set; }
    public DateTime ModifiedAt { get; set; }
  }
}
