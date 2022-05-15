using System;

namespace ShopList.Entities.Abstract
{
  public abstract class EntityBase
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
  }
}