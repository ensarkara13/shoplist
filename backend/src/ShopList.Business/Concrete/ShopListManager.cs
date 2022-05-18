using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.DTOs.ShoppingList;
using FluentValidation;
using FluentValidation.Results;
using AutoMapper;
using ShopList.Core.Extensions;
using ShopList.Entities.Concrete;

namespace ShopList.Business.Concrete
{
  public class ShopListManager : IShopListService
  {
    private readonly IShopListRepository _shopListRepository;
    private readonly IValidator<ShopListAddDto> _shopListAddValidator;
    private readonly IValidator<ShopListUpdateDto> _shopListUpdateValidator;
    private readonly IMapper _mapper;
    public ShopListManager(IShopListRepository shopListRepository, IValidator<ShopListAddDto> addValidator, IValidator<ShopListUpdateDto> updateValidator, IMapper mapper)
    {
      _shopListRepository = shopListRepository;
      _shopListAddValidator = addValidator;
      _shopListUpdateValidator = updateValidator;
      _mapper = mapper;
    }
    public async Task<Result> AddShopList(ShopListAddDto shopListDto)
    {
      ValidationResult validationResult = _shopListAddValidator.Validate(shopListDto);
      if (!validationResult.IsValid)
      {
        return Result.Failure(validationResult.ConvertToCustomErrors());
      }
      ShoppingList shopList = await _shopListRepository.Get(s => s.Name == shopListDto.Name);
      if (shopList != null)
      {
        return Result.Failure("Alışveriş listesi zaten mevcut.");
      }

      shopList = _mapper.Map<ShoppingList>(shopListDto);
      await _shopListRepository.Add(shopList);

      return Result.Success("Alışveriş Listesi başarı ile eklendi");
    }

    public async Task<Result> DeleteShopList(int id)
    {
      ShoppingList shoppingList = await _shopListRepository.Get(s => s.Id == id);
      if (shoppingList == null)
      {
        return Result.Failure("Silinecek alışveriş listesi bulunamadı.");
      }

      await _shopListRepository.Delete(shoppingList);
      return Result.Success("Alışveriş listesi başarı ile silindi");
    }

    public async Task<DataResult<ShopListGetDto>> GetShopList(int id, int userId)
    {
      ShoppingList shopList = await _shopListRepository.Get(s => s.UserId == userId && s.Id == id);
      if (shopList == null)
      {
        DataResult<ShopListGetDto>.Failure("İstenilen alışveriş listesi bulunamadı.");
      }

      ShopListGetDto shopListGetDto = _mapper.Map<ShopListGetDto>(shopList);

      return DataResult<ShopListGetDto>.Success(shopListGetDto);
    }

    public async Task<DataResult<List<ShopListGetDto>>> GetShopListList(int userId)
    {
      List<ShoppingList> shoppingLists = await _shopListRepository.GetAll(s => s.UserId == userId);
      if (shoppingLists == null)
      {
        return DataResult<List<ShopListGetDto>>.Failure("Kullanıcının hiç alışveriş listesi bulunmamaktadır.");
      }

      List<ShopListGetDto> shopListGetDtos = _mapper.Map<List<ShopListGetDto>>(shoppingLists);

      return DataResult<List<ShopListGetDto>>.Success(shopListGetDtos);
    }

    public async Task<Result> UpdateShopList(int id, ShopListUpdateDto shopListDto)
    {
      ShoppingList shoppingList = await _shopListRepository.Get(s => s.UserId == shopListDto.UserId && s.Name == shopListDto.Name);
      if (shoppingList != null)
      {
        return Result.Failure("Alışveriş listesi zaten mevcut.");
      }

      shoppingList = await _shopListRepository.Get(s => s.UserId == shopListDto.UserId && s.Id == id);

      shoppingList = _mapper.Map<ShopListUpdateDto, ShoppingList>(shopListDto, shoppingList);
      await _shopListRepository.Update(shoppingList);

      return Result.Success("Liste başarı ile güncellendi.");
    }
  }
}