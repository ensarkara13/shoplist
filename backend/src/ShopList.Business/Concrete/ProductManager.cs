using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.Product;

namespace ShopList.Business.Concrete
{
  public class ProductManager : IProductService
  {
    public Task<Result> AddProduct(ProductAddDto product)
    {
      throw new NotImplementedException();
    }

    public Task<Result> DeleteProduct(int id)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<ProductGetDto>> GetProduct(Expression<Func<ProductGetDto, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<List<ProductGetDto>>> GetProductList(Expression<Func<ProductGetDto, bool>> filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<Result> UpdateProduct(ProductUpdateDto product)
    {
      throw new NotImplementedException();
    }
  }
}