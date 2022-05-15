using System;

namespace ShopList.Entities.DTOs.Product
{
  public class ProductAddDto
  {
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
  }
}
