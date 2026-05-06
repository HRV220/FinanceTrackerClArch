using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Application.Wallets.Commands.CreateWallet;

public record CreateWalletCommand(
  Guid ProfileId,
  string Name,
  int SortOrder,
  CurrencyCode Currency,
  decimal InitialBalance,
  string? Icon = null,
  string? Note = null);
