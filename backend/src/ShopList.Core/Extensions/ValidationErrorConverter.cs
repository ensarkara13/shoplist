using FluentValidation.Results;
using ShopList.Core.Models;
using System.Collections.Generic;
using System.Text.Json;


namespace ShopList.Core.Extensions
{
  public static class ValidationErrorConverter
  {
    public static string ConvertToCustomErrors(this ValidationResult result)
    {
      List<CustomValidationError> customErrors = new List<CustomValidationError>();
      foreach (ValidationFailure failure in result.Errors)
      {
        customErrors.Add(new CustomValidationError()
        {
          PropertyName = failure.PropertyName,
          ErrorMessage = failure.ErrorMessage
        });
      }

      return JsonSerializer.Serialize(customErrors);
    }
  }
}