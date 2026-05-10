using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Transactions.Queries.GetTransactionById;

public record GetTransactionByIdResponse(
  Guid Id,
  Guid WalletId,
  Guid? CategoryId,
  FinancialType Type,
  decimal Amount,
  DateOnly Date,
  string? Description);
