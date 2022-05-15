using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.Category;

namespace ShopList.Business.Concrete
{
  public class CategoryManager : ICategoryService
  {
    public Task<Result> AddCategory(CategoryAddDto category)
    {
      throw new NotImplementedException();
    }

    public Task<Result> DeleteCategory(int id)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<CategoryGetDto>> GetCategory(Expression<Func<CategoryGetDto, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<List<CategoryGetDto>>> GetCategoryList(Expression<Func<CategoryGetDto, bool>> filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<Result> UpdateCategory(int id, CategoryUpdateDto category)
    {
      throw new NotImplementedException();
    }
  }
}