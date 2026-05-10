namespace FinanceTrackerAPI.Application.Currencies.Commands.UpdateCurrencyRate;

public record UpdateCurrencyRateCommand(Guid Id, decimal Rate, decimal UnitRate);
