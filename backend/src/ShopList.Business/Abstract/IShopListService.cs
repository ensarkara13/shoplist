using ShopList.Entities.DTOs.ShoppingList;
using ShopList.Core.Utilities.Results;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopList.Business.Abstract
{
  public interface IShopListService
  {
    Task<Result> AddShopList(ShopListAddDto shopList);
    Task<Result> DeleteShopList(int id);
    Task<Result> UpdateShopList(int id, ShopListUpdateDto shopList);
    Task<DataResult<ShopListGetDto>> GetShopList(int id, int userId);
    Task<DataResult<List<ShopListGetDto>>> GetShopListList(int userId);
  }
}