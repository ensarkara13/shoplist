using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.User;

namespace ShopList.Business.Concrete
{
  public class UserManager : IUserService
  {
    public Task<Result> AddUser(UserAddDto user)
    {
      throw new NotImplementedException();
    }

    public Task<Result> DeleteUser(int id)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<UserGetDto>> GetUser(Expression<Func<UserGetDto, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public Task<DataResult<List<UserGetDto>>> GetUserList(Expression<Func<UserGetDto, bool>> filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<Result> UpdateUser(int id, UserUpdateDto user)
    {
      throw new NotImplementedException();
    }
  }
}