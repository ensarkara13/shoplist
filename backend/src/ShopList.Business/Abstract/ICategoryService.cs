using ShopList.Entities.DTOs.Category;
using ShopList.Core.Utilities.Results;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopList.Business.Abstract
{
  public interface ICategoryService
  {
    Task<Result> AddCategory(CategoryAddDto category);
    Task<Result> DeleteCategory(int id);
    Task<Result> UpdateCategory(int id, CategoryUpdateDto category);
    Task<DataResult<CategoryGetDto>> GetCategory(Expression<Func<CategoryGetDto, bool>> filter);
    Task<DataResult<List<CategoryGetDto>>> GetCategoryList(Expression<Func<CategoryGetDto, bool>> filter = null);
  }
}