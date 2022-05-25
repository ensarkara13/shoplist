using System;

namespace ShopList.Entities.DTOs.Category
{
  public class CategoryGetDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
  }
}
