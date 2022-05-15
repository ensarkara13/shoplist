using System;
using System.Collections.Generic;
using ShopList.Entities.Concrete;

namespace ShopList.Entities.DTOs.ShoppingListProduct
{
  public class ShopListProductAddDto
  {
    public string Description { get; set; }
    public int ShopListId { get; set; }
    public int ProductId { get; set; }
  }
}
