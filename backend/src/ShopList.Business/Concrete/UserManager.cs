using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.Concrete;
using ShopList.Entities.DTOs.User;
using ShopList.Core.Extensions;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace ShopList.Business.Concrete
{
  public class UserManager : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly IValidator<UserAddDto> _userAddValidator;
    private readonly IValidator<UserUpdateDto> _userUpdateValidator;
    private readonly IPasswordHasher<string> _passwordHasher;
    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IValidator<UserAddDto> userAddValidator, IValidator<UserUpdateDto> userUpdateValidator, IPasswordHasher<string> hasher, IMapper mapper)
    {
      _userRepository = userRepository;
      _userAddValidator = userAddValidator;
      _userUpdateValidator = userUpdateValidator;
      _passwordHasher = hasher;
      _mapper = mapper;
    }

    public async Task<Result> AddUser(UserAddDto userDto)
    {
      ValidationResult validationResult = _userAddValidator.Validate(userDto);
      if (validationResult.IsValid)
      {
        User user = await _userRepository.Get(u => u.Email == userDto.Email);

        if (user != null)
        {
          return Result.Failure("Kullanıcı zaten kayıtlı");
        }

        user = _mapper.Map<User>(userDto);
        user.Password = _passwordHasher.HashPassword(userDto.Email, userDto.Password);
        user.Role = string.IsNullOrEmpty(userDto.Role) ? "User" : userDto.Role;

        await _userRepository.Add(user);

        return Result.Success("Kayıt işlemi başarılı.");
      }
      return Result.Failure(validationResult.ConvertToCustomErrors());
    }

    public async Task<Result> DeleteUser(int id)
    {
      User user = await _userRepository.Get(u => u.Id == id);
      if (user == null)
      {
        return Result.Failure("Silinmek istenen kullanıcı bulunamadı.");
      }
      await _userRepository.Delete(user);
      return Result.Success("Silme işlemi başarılı.");
    }

    public async Task<DataResult<UserGetDto>> GetUserByEmail(string email)
    {
      User user = await _userRepository.Get(u => u.Email == email);
      if (user == null)
      {
        return DataResult<UserGetDto>.Failure("Kullanıcı bulunamadı.");
      }
      UserGetDto userGet = _mapper.Map<UserGetDto>(user);

      return DataResult<UserGetDto>.Success(userGet);
    }

    public Task<DataResult<List<UserGetDto>>> GetUserList(Expression<Func<UserGetDto, bool>> filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<Result> UpdateUser(int id, UserUpdateDto userDto)
    {
      throw new NotImplementedException();
    }
  }
}