using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Entities.DTOs.User;
using ShopList.Core.Utilities.Results;
using ShopList.WebApi.Models.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using ShopList.WebApi.Helpers;

namespace ShopList.WebApi.Controllers
{
  [ApiController]
  [Route("auth")]
  public class AuthController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly IPasswordHasher<string> _passwordHasher;
    private readonly IConfiguration _configuration;
    public AuthController(IUserService userService, IConfiguration configuration, IPasswordHasher<string> hasher)
    {
      _userService = userService;
      _configuration = configuration;
      _passwordHasher = hasher;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserAddDto user)
    {
      Result result = await _userService.AddUser(user);

      if (result.IsSuccess)
      {
        return StatusCode(201, user);
      }

      return BadRequest(result.Message);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(UserLoginDto user)
    {
      DataResult<UserGetDto> result = await _userService.GetUserByEmail(user.Email);
      if (result.IsSuccess)
      {
        int verificationResult = (int)(_passwordHasher.VerifyHashedPassword(result.Data.Email, result.Data.Password, user.Password));
        if (verificationResult == 1)
        {

          string accessToken = JwtHelper.GenerateAccessToken(_configuration, result.Data.Role);

          return Ok(accessToken);
        }
        
        return BadRequest("Hatalı şifre");
      }

      return BadRequest(result.Message);
    }
  }
}