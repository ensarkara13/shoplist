using System.Collections.Generic;
using ShopList.Core.Models;

namespace ShopList.Core.Utilities.Results
{
  public class DataResult<T> : IResult
  {
    internal DataResult()
    {
      Data = default!;
    }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<CustomValidationError> ErrorMessages { get; set; }

    public T Data { get; set; }
    public static DataResult<T> Success(T data)
    {
      return new DataResult<T>()
      {
        IsSuccess = true,
        Data = data
      };
    }
    public static DataResult<T> Success(T data, string message)
    {
      return new DataResult<T>()
      {
        IsSuccess = true,
        Data = data,
        Message = message
      };
    }
    public static DataResult<T> Failure(string message)
    {
      return new DataResult<T>()
      {
        IsSuccess = false,
        Message = message
      };
    }
    public static DataResult<T> Failure(string message, List<CustomValidationError> errorMessages)
    {
      return new DataResult<T>()
      {
        IsSuccess = false,
        Message = message,
        ErrorMessages = errorMessages
      };
    }
  }
}