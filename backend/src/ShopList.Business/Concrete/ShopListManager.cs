using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.ShoppingList;

namespace ShopList.Business.Concrete
{
  public class ShopListManager : IShopListService
  {
    public Task<Result> AddShopList(ShopListAddDto shopList)
    {
      throw new NotImplementedException();
    }

    public Task<Result> DeleteShopList(int id)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<ShopListGetDto>> GetShopList(Expression<Func<ShopListGetDto, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<List<ShopListGetDto>>> GetShopListList(Expression<Func<ShopListGetDto, bool>> filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<Result> UpdateShopList(ShopListUpdateDto shopList)
    {
      throw new NotImplementedException();
    }
  }
}