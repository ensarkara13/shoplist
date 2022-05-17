using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ShopList.Entities.DTOs.Category;
using ShopList.Core.Utilities.Results;
using ShopList.Business.Abstract;

namespace ShopList.WebApi.Controllers
{
  [ApiController]
  [Authorize]
  [Route("categories")]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCategory(CategoryAddDto categoryDto)
    {
      Result result = await _categoryService.AddCategory(categoryDto);

      if (result.IsSuccess)
      {
        return StatusCode(201, result.Message);
      }

      return BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      Result result = await _categoryService.DeleteCategory(id);

      if (result.IsSuccess)
      {
        return NoContent();
      }

      return BadRequest(result.Message);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoryList()
    {
      DataResult<List<CategoryGetDto>> result = await _categoryService.GetCategoryList();

      if (result.IsSuccess)
      {
        return Ok(result.Data);
      }

      return BadRequest(result.Message);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryUpdateDto categoryDto)
    {
      Result result = await _categoryService.UpdateCategory(id, categoryDto);

      if (result.IsSuccess)
      {
        return Ok(result.Message);
      }

      return BadRequest(result.Message);
    }
  }
}