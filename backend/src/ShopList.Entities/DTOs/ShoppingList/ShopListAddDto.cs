using System;

namespace ShopList.Entities.DTOs.ShoppingList
{
  public class ShopListAddDto
  {
    public string Name { get; set; }
    public bool IsShopping { get; set; }
    public bool IsFinished { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
  }
}
