using System;

namespace ShopList.Entities.DTOs.Category
{
  public class CategoryAddDto
  {
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
  }
}
