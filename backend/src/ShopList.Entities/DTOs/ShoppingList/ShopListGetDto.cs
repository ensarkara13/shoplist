using System;
using System.Collections.Generic;
using ShopList.Entities.Concrete;

namespace ShopList.Entities.DTOs.ShoppingList
{
  public class ShopListGetDto
  {
    public string Name { get; set; }
    public bool IsShopping { get; set; }
    public bool IsFinished { get; set; }
  }
}
