using ShopList.Entities.Abstract;

namespace ShopList.Entities.Concrete
{
  public class ShopListProduct
  {
    public string Description { get; set; }

    public int ShopListId { get; set; }
    public ShoppingList ShoppingList { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
  }
}