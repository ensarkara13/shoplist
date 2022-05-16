using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Entities.DTOs.User;
using ShopList.Core.Utilities.Results;

namespace ShopList.WebApi.Controllers
{
  [ApiController]
  [Route("auth")]
  public class AuthController : ControllerBase
  {
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserAddDto user)
    {
      Result result = await _userService.AddUser(user);

      if (result.IsSuccess)
      {
        return StatusCode(201);
      }
      return BadRequest(result.Message);
    }
  }
}