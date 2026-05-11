using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Transactions.Commands.CreateTransaction;

public record CreateTransactionCommand(
  Guid WalletId,
  FinancialType Type,
  decimal Amount,
  DateOnly Date,
  Guid? CategoryId = null,
  string? Description = null,
  Guid? ToWalletId = null);
