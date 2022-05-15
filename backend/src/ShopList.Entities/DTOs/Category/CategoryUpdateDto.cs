using System;

namespace ShopList.Entities.DTOs.Category
{
  public class CategoryUpdateDto
  {
    public string Name { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string ModifiedBy { get; set; }
  }
}
