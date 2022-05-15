using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ShopList.DataAccess.Repositories.Concrete
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
  {
    private readonly ShopListDbContext _context;
    public GenericRepository(ShopListDbContext context)
    {
      _context = context;
    }
    public async Task Add(T entity)
    {
      await _context.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task AddRange(List<T> entityList)
    {
      await _context.AddRangeAsync(entityList);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>> filter)
    {
      return await _context.Set<T>().SingleOrDefaultAsync(filter);
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
    {
      if (filter == null)
      {
        return await _context.Set<T>().ToListAsync();
      }
      return await _context.Set<T>().Where(filter).ToListAsync();
    }

    public async Task Update(T entity)
    {
      _context.Update(entity);
      await _context.SaveChangesAsync();
    }
  }
}