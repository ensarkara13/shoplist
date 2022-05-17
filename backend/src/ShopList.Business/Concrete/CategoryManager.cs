using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.Category;
using ShopList.DataAccess.Repositories.Abstract;
using FluentValidation;
using AutoMapper;
using FluentValidation.Results;
using ShopList.Core.Extensions;
using ShopList.Entities.Concrete;

namespace ShopList.Business.Concrete
{
  public class CategoryManager : ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;
    private readonly IValidator<CategoryAddDto> _categoryAddValidator;
    private readonly IValidator<CategoryUpdateDto> _categoryUpdateValidator;
    private readonly IMapper _mapper;
    public CategoryManager(ICategoryRepository categoryRepository, IValidator<CategoryAddDto> categoryAddValidator, IValidator<CategoryUpdateDto> categoryUpdateValidator, IMapper mapper)
    {
      _categoryRepository = categoryRepository;
      _categoryAddValidator = categoryAddValidator;
      _categoryUpdateValidator = categoryUpdateValidator;
      _mapper = mapper;
    }

    public async Task<Result> AddCategory(CategoryAddDto categoryDto)
    {
      ValidationResult validationResult = _categoryAddValidator.Validate(categoryDto);
      if (validationResult.IsValid)
      {
        Category category = await _categoryRepository.Get(c => c.Name == categoryDto.Name);
        if (category != null)
        {
          return Result.Failure("Kategori zaten mevcut.");
        }
        category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Add(category);

        return Result.Success("Kategori başarı ile eklendi");
      }
      return Result.Failure(validationResult.ConvertToCustomErrors());
    }

    public async Task<Result> DeleteCategory(int id)
    {
      Category category = await _categoryRepository.Get(c => c.Id == id);

      if (category == null)
      {
        return Result.Failure("Silinecek kategori bulunamadı.");
      }

      await _categoryRepository.Delete(category);

      return Result.Success("Kategori başarı ile silindi");
    }

    public async Task<DataResult<CategoryGetDto>> GetCategoryById(int id)
    {
      Category category = await _categoryRepository.Get(c => c.Id == id);
      if (category == null)
      {
        return DataResult<CategoryGetDto>.Failure("İstenen kategori bulunamadı.");
      }
      CategoryGetDto categoryGet = _mapper.Map<CategoryGetDto>(category);

      return DataResult<CategoryGetDto>.Success(categoryGet);
    }

    public async Task<DataResult<List<CategoryGetDto>>> GetCategoryList()
    {
      List<Category> categoryList = await _categoryRepository.GetAll();

      if (categoryList == null)
      {
        return DataResult<List<CategoryGetDto>>.Failure("Hiç kategori bulunmamaktadır.");
      }

      List<CategoryGetDto> categoryGetDtos = _mapper.Map<List<CategoryGetDto>>(categoryList);

      return DataResult<List<CategoryGetDto>>.Success(categoryGetDtos);
    }

    public async Task<Result> UpdateCategory(int id, CategoryUpdateDto categoryDto)
    {
      Category category = await _categoryRepository.Get(c => c.Name == categoryDto.Name);
      if (category != null)
      {
        return Result.Failure("Aynı isimde birden fazla kategori olamaz.");
      }

      category = await _categoryRepository.Get(c => c.Id == id);
      if (category == null)
      {
        return Result.Failure("Güncellenecek kategori bulunamadı.");
      }

      ValidationResult validationResult = _categoryUpdateValidator.Validate(categoryDto);
      if (validationResult.IsValid)
      {
        category = _mapper.Map<CategoryUpdateDto, Category>(categoryDto, category);
        await _categoryRepository.Update(category);

        return Result.Success("Güncelleme işlemi başarılı.");
      }

      return Result.Failure(validationResult.ConvertToCustomErrors());
    }
  }
}