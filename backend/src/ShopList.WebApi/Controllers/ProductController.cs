using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.Entities.DTOs.Product;
using ShopList.Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using ShopList.Business.Abstract;

namespace ShopList.WebApi.Controllers
{
  [ApiController]
  [Route("products")]
  [Authorize]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
    {
      Result result = await _productService.AddProduct(productAddDto);

      if (result.IsSuccess)
      {
        return StatusCode(201, result.Message);
      }

      return BadRequest(result.ErrorMessages);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
      Result result = await _productService.DeleteProduct(id);
      if (result.IsSuccess)
      {
        return NoContent();
      }

      return BadRequest(result.ErrorMessages);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductList()
    {
      DataResult<List<ProductGetDto>> result = await _productService.GetProductList();
      if (result.IsSuccess)
      {
        return Ok(result.Data);
      }

      return BadRequest(result.ErrorMessages);
    }

    [HttpGet("category")]
    public async Task<IActionResult> GetProductListByCategory([FromQuery] int categoryId)
    {
      DataResult<List<ProductGetDto>> result = await _productService.GetProductListByCategory(categoryId);
      if (result.IsSuccess)
      {
        return Ok(result.Data);
      }

      return BadRequest(result.ErrorMessages);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
    {
      Result result = await _productService.UpdateProduct(id, productUpdateDto);
      if (result.IsSuccess)
      {
        return Ok(result.Message);
      }

      return BadRequest(result.ErrorMessages);
    }
  }
}