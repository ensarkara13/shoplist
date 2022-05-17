using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.User;

namespace ShopList.Business.Abstract
{
  public interface IUserService
  {
    Task<Result> AddUser(UserAddDto user);
    Task<Result> DeleteUser(int id);
    Task<Result> UpdateUser(int id, UserUpdateDto user);
    Task<DataResult<UserGetDto>> GetUserByEmail(string email);
    Task<DataResult<List<UserGetDto>>> GetUserList(Expression<Func<UserGetDto, bool>> filter = null);
  }
}