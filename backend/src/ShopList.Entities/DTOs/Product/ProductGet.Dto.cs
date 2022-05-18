using System;

namespace ShopList.Entities.DTOs.Product
{
  public class ProductGetDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string ModifiedBy { get; set; }
  }
}
