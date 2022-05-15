using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.ShopListProduct;

namespace ShopList.Business.Concrete
{
  public class ShopListProductManager : IShopListProductService
  {
    public Task<Result> AddRangeShopListProduct(List<ShopListProductAddDto> shopListProducts)
    {
      throw new NotImplementedException();
    }

    public Task<Result> AddShopListProduct(ShopListProductAddDto shopListProduct)
    {
      throw new NotImplementedException();
    }

    public Task<Result> DeleteShopListProduct()
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<ShopListProductGetDto>> GetShopListProduct(Expression<Func<ShopListProductGetDto, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<List<ShopListProductGetDto>>> GetShopListProductList(Expression<Func<ShopListProductGetDto, bool>> filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<Result> UpdateShopListProduct(ShopListProductUpdateDto shopListProduct)
    {
      throw new NotImplementedException();
    }
  }
}