namespace FinanceTrackerAPI.Domain.ValueObject;

public sealed record Currency
{
  public CurrencyCode Code {get; init;} = CurrencyCode.RUB;
  public static Result<Currency> Create(CurrencyCode code)
  {
    return Result<Currency>.Success(new Currency{Code = code});
  }
}
