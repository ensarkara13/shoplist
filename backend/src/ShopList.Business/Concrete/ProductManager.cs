using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopList.Business.Abstract;
using ShopList.Core.Utilities.Results;
using ShopList.DataAccess.Repositories.Abstract;
using ShopList.Entities.DTOs.Product;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using ShopList.Core.Extensions;
using ShopList.Entities.Concrete;

namespace ShopList.Business.Concrete
{
  public class ProductManager : IProductService
  {
    private readonly IProductRepository _productRepository;
    private readonly IValidator<ProductAddDto> _productAddValidator;
    private readonly IValidator<ProductUpdateDto> _productUpdateValidator;
    private readonly IMapper _mapper;
    public ProductManager(IProductRepository productRepository, IValidator<ProductAddDto> productAddValidator, IValidator<ProductUpdateDto> productUpdateValidator, IMapper mapper)
    {
      _productRepository = productRepository;
      _productAddValidator = productAddValidator;
      _productUpdateValidator = productUpdateValidator;
      _mapper = mapper;
    }

    public async Task<Result> AddProduct(ProductAddDto productDto)
    {
      ValidationResult validationResult = _productAddValidator.Validate(productDto);
      if (!validationResult.IsValid)
      {
        return Result.Failure(validationResult.ConvertToCustomErrors());
      }
      
      Product product = await _productRepository.Get(p => p.Name == productDto.Name);
      if (product != null)
      {
        return Result.Failure("Ürün zaten mevcut");
      }

      product = _mapper.Map<Product>(productDto);
      await _productRepository.Add(product);

      return Result.Success("Ürün ekleme işlemi başarılı.");

    }

    public async Task<Result> DeleteProduct(int id)
    {
      Product product = await _productRepository.Get(p => p.Id == id);
      if (product == null)
      {
        return Result.Failure("Silinecek ürün bulunamadı.");
      }

      await _productRepository.Delete(product);
      return Result.Success("Ürün başarı ile silindi.");
    }

    public async Task<DataResult<ProductGetDto>> GetProductById(int id)
    {
      Product product = await _productRepository.Get(p => p.Id == id);
      if (product == null)
      {
        return DataResult<ProductGetDto>.Failure("İstenilen ürün bulunamadı.");
      }

      ProductGetDto productGetDto = _mapper.Map<ProductGetDto>(product);

      return DataResult<ProductGetDto>.Success(productGetDto);
    }

    public async Task<DataResult<List<ProductGetDto>>> GetProductList()
    {
      List<Product> productList = await _productRepository.GetAll();
      if (productList == null)
      {
        return DataResult<List<ProductGetDto>>.Failure("Hiç ürün bulunmamaktadır.");
      }

      List<ProductGetDto> productGetDtos = _mapper.Map<List<ProductGetDto>>(productList);
      return DataResult<List<ProductGetDto>>.Success(productGetDtos);
    }

    public async Task<Result> UpdateProduct(int id, ProductUpdateDto productDto)
    {
      Product product = await _productRepository.Get(p => p.Name == productDto.Name);
      if (product != null)
      {
        return Result.Failure("Aynı isimde birden fazla ürün olamaz");
      }
      product = await _productRepository.Get(p => p.Id == id);
      if (product == null)
      {
        return Result.Failure("Güncellenecek ürün bulunamadı.");
      }

      product = _mapper.Map<ProductUpdateDto, Product>(productDto, product);

      return Result.Success("Güncelleme işlemi başarılı.");
    }
  }
}