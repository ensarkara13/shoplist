using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Entities.DTOs.ShoppingList;
using ShopList.Core.Utilities.Results;

namespace ShopList.WebApi.Controllers
{
  [ApiController]
  [Authorize(Roles = "User")]
  [Route("shoplists")]
  public class ShopListController : ControllerBase
  {
    private readonly IShopListService _shopListService;
    public ShopListController(IShopListService shopListService)
    {
      _shopListService = shopListService;
    }

    [HttpPost]
    public async Task<IActionResult> AddShopList(ShopListAddDto shopListAddDto)
    {
      Result result = await _shopListService.AddShopList(shopListAddDto);

      if (result.IsSuccess)
      {
        return StatusCode(201, result.Message);
      }

      return BadRequest(result.ErrorMessages);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShopList(int id)
    {
      Result result = await _shopListService.DeleteShopList(id);

      if (result.IsSuccess)
      {
        return NoContent();
      }

      return BadRequest(result.ErrorMessages);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetShopLists(int userId)
    {
      DataResult<List<ShopListGetDto>> result = await _shopListService.GetShopListList(userId);

      if (result.IsSuccess)
      {
        return Ok(result.Data);
      }

      return BadRequest(result.ErrorMessages);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShopList(int id, ShopListUpdateDto shopList)
    {
      Result result = await _shopListService.UpdateShopList(id, shopList);

      if (result.IsSuccess)
      {
        return Ok(result.Message);
      }

      return BadRequest(result.ErrorMessages);
    }
  }
}