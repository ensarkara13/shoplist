using ShopList.Entities.DTOs.Product;
using ShopList.Core.Utilities.Results;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopList.Business.Abstract
{
  public interface IProductService
  {
    Task<Result> AddProduct(ProductAddDto product);
    Task<Result> DeleteProduct(int id);
    Task<Result> UpdateProduct(ProductUpdateDto product);
    Task<DataResult<ProductGetDto>> GetProduct(Expression<Func<ProductGetDto, bool>> filter);
    Task<DataResult<List<ProductGetDto>>> GetProductList(Expression<Func<ProductGetDto, bool>> filter = null);
  }
}