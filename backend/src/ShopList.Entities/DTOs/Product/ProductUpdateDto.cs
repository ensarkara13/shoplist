using System;

namespace ShopList.Entities.DTOs.Product
{
  public class ProductUpdateDto
  {
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string ModifiedBy { get; set; }
  }
}
