using System;
using System.Collections.Generic;
using ShopList.Entities.DTOs.Product;

namespace ShopList.Entities.DTOs.Category
{
  public class CategoryGetWithProductsDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public List<ProductGetDto> Products { get; set; }
  }
}
