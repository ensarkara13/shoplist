using ShopList.Entities.DTOs.Category;
using ShopList.Core.Utilities.Results;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.Entities.Concrete;

namespace ShopList.Business.Abstract
{
  public interface ICategoryService
  {
    Task<Result> AddCategory(CategoryAddDto category);
    Task<Result> DeleteCategory(int id);
    Task<Result> UpdateCategory(int id, CategoryUpdateDto category);
    Task<DataResult<CategoryGetDto>> GetCategoryById(int id);
    Task<DataResult<List<CategoryGetDto>>> GetCategoryList();
    Task<DataResult<List<CategoryGetWithProductsDto>>> GetCategoriesWithProducts();
  }
}