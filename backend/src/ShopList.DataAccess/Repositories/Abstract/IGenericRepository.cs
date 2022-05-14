using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;


namespace ShopList.DataAccess.Repositories.Abstract
{
  public interface IGenericRepository<T> where T : class, new()
  {
    Task Add(T entity);
    Task Delete(T entity);
    Task Update(T entity);
    Task<T> Get(Expression<Func<T, bool>> filter);
    Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
  }
}