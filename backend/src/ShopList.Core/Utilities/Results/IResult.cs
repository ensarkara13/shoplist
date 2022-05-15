namespace ShopList.Core.Utilities.Results
{
  public interface IResult
  {
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
  }
}