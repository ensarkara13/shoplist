using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.Entities.DTOs.ShopListProduct;
using FluentValidation;
using FluentValidation.Results;
using AutoMapper;
using ShopList.Entities.Concrete;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Core.Extensions;

namespace ShopList.Business.Concrete
{
  public class ShopListProductManager : IShopListProductService
  {
    private readonly IShopListProductRepository _shopListProductRepository;
    private readonly IValidator<ShopListProductAddDto> _shopListProductAddValidator;
    private readonly IValidator<ShopListProductUpdateDto> _shopListProductUpdateValidator;
    private readonly IMapper _mapper;
    public ShopListProductManager(IShopListProductRepository shopListProductRepository, IValidator<ShopListProductAddDto> addValidator, IValidator<ShopListProductUpdateDto> updateValidator, IMapper mapper)
    {
      _shopListProductRepository = shopListProductRepository;
      _shopListProductAddValidator = addValidator;
      _shopListProductUpdateValidator = updateValidator;
      _mapper = mapper;
    }

    public async Task<Result> AddRangeShopListProduct(List<ShopListProductAddDto> shopListProductAddDtos)
    {
      foreach (ShopListProductAddDto shopListProductAddDto in shopListProductAddDtos)
      {
        ValidationResult validationResult = _shopListProductAddValidator.Validate(shopListProductAddDto);
        if (!validationResult.IsValid)
        {
          return Result.Failure(validationResult.ConvertToCustomErrors());
        }
      }

      List<ShopListProduct> shopListProducts = _mapper.Map<List<ShopListProduct>>(shopListProductAddDtos);
      await _shopListProductRepository.AddRange(shopListProducts);

      return Result.Success();
    }

    public async Task<Result> AddShopListProduct(ShopListProductAddDto shopListProductDto)
    {
      ValidationResult validationResult = _shopListProductAddValidator.Validate(shopListProductDto);
      if (!validationResult.IsValid)
      {
        return Result.Failure(validationResult.ConvertToCustomErrors());
      }

      ShopListProduct shopListProduct = _mapper.Map<ShopListProduct>(shopListProductDto);
      await _shopListProductRepository.Add(shopListProduct);

      return Result.Success("Ürün başarı ile listeye eklendi.");
    }

    public async Task<Result> DeleteShopListProduct(ShopListProductDto shopListProductDto)
    {
      ShopListProduct shopListProduct = await _shopListProductRepository.Get(s => s.ProductId == shopListProductDto.ProductId && s.ShopListId == shopListProductDto.ShopListId);
      if (shopListProduct == null)
      {
        return Result.Failure("Silinecek ürün bulunamadı.");
      }
      await _shopListProductRepository.Delete(shopListProduct);

      return Result.Success("Ürün başarı ile silindi");
    }

    public async Task<DataResult<ShopListProductGetDto>> GetShopListProduct(ShopListProductDto shopListProductDto)
    {
      ShopListProduct shopListProduct = await _shopListProductRepository.Get(s => s.ProductId == shopListProductDto.ProductId && s.ShopListId == shopListProductDto.ShopListId);

      if (shopListProduct == null)
      {
        return DataResult<ShopListProductGetDto>.Failure("İstenilen ürün bulunamadı.");
      }

      ShopListProductGetDto shopListProductGetDto = _mapper.Map<ShopListProductGetDto>(shopListProduct);

      return DataResult<ShopListProductGetDto>.Success(shopListProductGetDto);
    }

    public async Task<DataResult<List<ShopListProductGetDto>>> GetShopListProductList(int shopListId)
    {
      List<ShopListProduct> shopListProducts = await _shopListProductRepository.GetAll(s => s.ShopListId == shopListId);
      if (shopListProducts == null)
      {
        return DataResult<List<ShopListProductGetDto>>.Failure("Bu listede hiç ürün bulunmamaktadır.");
      }

      List<ShopListProductGetDto> shopListProductGetDtos = _mapper.Map<List<ShopListProductGetDto>>(shopListProducts);

      return DataResult<List<ShopListProductGetDto>>.Success(shopListProductGetDtos);
    }

    public async Task<Result> UpdateShopListProduct(ShopListProductUpdateDto shopListProductUpdateDto)
    {
      ShopListProduct shopListProduct = await _shopListProductRepository.Get(s => s.ProductId == shopListProductUpdateDto.ProductId && s.ShopListId == shopListProductUpdateDto.ShopListId);

      if (shopListProduct == null)
      {
        return Result.Failure("Güncellenecek ürün bulunamadı.");
      }

      shopListProduct = _mapper.Map<ShopListProductUpdateDto, ShopListProduct>(shopListProductUpdateDto, shopListProduct);
      await _shopListProductRepository.Update(shopListProduct);

      return Result.Success("Ürün başarı ile güncellendi");
    }
  }
}