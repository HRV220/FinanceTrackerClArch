using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Application.Wallets.Queries.GetWalletsByProfileId;

public record GetWalletsByProfileIdResponse(
  Guid Id,
  Guid ProfileId,
  string Name,
  string? Icon,
  int SortOrder,
  CurrencyCode Currency,
  decimal InitialBalance,
  string? Note,
  bool IsArchived);
