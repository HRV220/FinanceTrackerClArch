namespace FinanceTrackerAPI.Domain.Common;
public class Result<T>
{
  public T? Value {get; private set;}
  public DomainError? Error {get; private set;}
  public bool IsSuccess {get;private set;}
  public bool IsFailure => !IsSuccess;

  private Result(T value)
  {
    this.Value = value;
    IsSuccess = true;
  }

  private Result(DomainError error)
  {
    this.Error = error;
    IsSuccess = false;
  }

  public static Result<T> Success(T value)
  {
    return new Result<T> (value);
  }

    public static Result<T> Failure(DomainError error)
  {
    return new Result<T> (error);
  }

}