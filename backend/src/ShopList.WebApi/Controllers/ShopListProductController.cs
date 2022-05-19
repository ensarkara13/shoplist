using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Entities.DTOs.ShopListProduct;
using ShopList.Core.Utilities.Results;

namespace ShopList.WebApi.Controllers
{
  [ApiController]
  [Authorize(Roles = "User")]
  [Route("shoplistproducts")]
  public class ShopListProductController : ControllerBase
  {
    private readonly IShopListProductService _shopListProductService;
    public ShopListProductController(IShopListProductService shopListProductService)
    {
      _shopListProductService = shopListProductService;
    }

    [HttpPost]
    public async Task<IActionResult> AddShopListProduct(ShopListProductAddDto shopListProductAddDto)
    {
      Result result = await _shopListProductService.AddShopListProduct(shopListProductAddDto);

      if (result.IsSuccess)
      {
        return StatusCode(201, result.Message);
      }

      return BadRequest(result.Message);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteShopListProduct(ShopListProductDto shopListProductDto)
    {
      Result result = await _shopListProductService.DeleteShopListProduct(shopListProductDto);

      if (result.IsSuccess)
      {
        return NoContent();
      }

      return BadRequest(result.Message);
    }

    [HttpGet("{shopListId}")]
    public async Task<IActionResult> GetShopListProductList(int shopListId)
    {
      DataResult<List<ShopListProductGetDto>> result = await _shopListProductService.GetShopListProductList(shopListId);

      if (result.IsSuccess)
      {
        return Ok(result.Data);
      }

      return BadRequest(result.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateShopListProduct(ShopListProductUpdateDto shopListProductUpdateDto)
    {
      Result result = await _shopListProductService.UpdateShopListProduct(shopListProductUpdateDto);

      if (result.IsSuccess)
      {
        return Ok(result.Message);
      }

      return BadRequest(result.Message);
    }
  }
}