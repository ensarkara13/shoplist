using System.Collections.Generic;
using ShopList.Core.Models;

namespace ShopList.Core.Utilities.Results
{
  public interface IResult
  {
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<CustomValidationError> ErrorMessages { get; set; }
  }
}