namespace ShopList.Core.Utilities.Results
{
  public class Result : IResult
  {
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public static Result Success()
    {
      return new Result()
      {
        IsSuccess = true
      };
    }
    public static Result Success(string message)
    {
      return new Result
      {
        IsSuccess = true,
        Message = message
      };
    }
    public static Result Failure(string message)
    {
      return new Result
      {
        IsSuccess = false,
        Message = message
      };
    }
  }
}