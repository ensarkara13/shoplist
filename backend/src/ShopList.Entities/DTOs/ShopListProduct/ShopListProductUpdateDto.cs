using System;
using System.Collections.Generic;
using ShopList.Entities.Concrete;

namespace ShopList.Entities.DTOs.ShopListProduct
{
  public class ShopListProductUpdateDto
  {
    public string Description { get; set; }
    public int ShopListId { get; set; }
    public int ProductId { get; set; }
  }
}
