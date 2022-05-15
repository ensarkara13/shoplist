using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.ShopListProduct;

namespace ShopList.Business.Abstract
{
  public interface IShopListProductService
  {
    Task<Result> AddShopListProduct(ShopListProductAddDto shopListProduct);
    Task<Result> AddRangeShopListProduct(List<ShopListProductAddDto> shopListProducts);
    Task<Result> DeleteShopListProduct();
    Task<Result> UpdateShopListProduct(ShopListProductUpdateDto shopListProduct);
    Task<DataResult<ShopListProductGetDto>> GetShopListProduct(Expression<Func<ShopListProductGetDto, bool>> filter);
    Task<DataResult<List<ShopListProductGetDto>>> GetShopListProductList(Expression<Func<ShopListProductGetDto, bool>> filter = null);
  }
}