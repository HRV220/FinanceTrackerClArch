using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Application.Wallets.Commands.ChangeCurrency;

public record ChangeCurrencyCommand(Guid Id, CurrencyCode NewCurrency);
