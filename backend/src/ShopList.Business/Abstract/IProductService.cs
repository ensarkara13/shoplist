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
    Task<Result> UpdateProduct(int id, ProductUpdateDto productDto);
    Task<DataResult<ProductGetDto>> GetProductById(int id);
    Task<DataResult<List<ProductGetDto>>> GetProductList();
  }
}