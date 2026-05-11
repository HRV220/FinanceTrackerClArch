using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Currencies.Commands.UpdateCurrencyRate;

public class UpdateCurrencyRateCommandHandler
{
  private readonly ICurrencyRepository _currencyRepository;

  public UpdateCurrencyRateCommandHandler(ICurrencyRepository currencyRepository)
  {
    _currencyRepository = currencyRepository;
  }

  public async Task<Result<bool>> Handle(UpdateCurrencyRateCommand command)
  {
    var currency = await _currencyRepository.GetByIdAsync(command.Id);
    if (currency is null)
      return Result<bool>.Failure(new DomainError("Currency.NotFound", "Currency not found."));

    currency.UpdateRate(command.Rate, command.UnitRate);
    await _currencyRepository.UpdateAsync(currency);
    return Result<bool>.Success(true);
  }
}
