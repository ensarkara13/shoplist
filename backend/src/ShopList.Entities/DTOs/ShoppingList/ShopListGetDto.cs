using System;
using System.Collections.Generic;
using ShopList.Entities.Concrete;

namespace ShopList.Entities.DTOs.ShoppingList
{
  public class ShopListGetDto
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public bool IsShopping { get; set; }
    public bool IsFinished { get; set; }
  }
}
