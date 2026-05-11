using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.RecurringTransactions.Commands.CreateRecurringTransaction;

public record CreateRecurringTransactionCommand(
  Guid WalletId,
  FinancialType Type,
  decimal Amount,
  RecurrenceInterval Interval,
  DateOnly StartDate,
  Guid? CategoryId = null,
  string? Description = null,
  Guid? ToWalletId = null,
  DateOnly? EndDate = null);
