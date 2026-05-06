using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Application.Wallets.Queries.GetWalletById;

public record GetWalletByIdResponse(
  Guid Id,
  Guid ProfileId,
  string Name,
  string? Icon,
  int SortOrder,
  CurrencyCode Currency,
  decimal InitialBalance,
  string? Note,
  bool IsArchived);
