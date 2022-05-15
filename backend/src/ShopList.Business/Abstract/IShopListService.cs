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
    Task<Result> UpdateShopList(ShopListUpdateDto shopList);
    Task<DataResult<ShopListGetDto>> GetShopList(Expression<Func<ShopListGetDto, bool>> filter);
    Task<DataResult<List<ShopListGetDto>>> GetShopListList(Expression<Func<ShopListGetDto, bool>> filter = null);
  }
}