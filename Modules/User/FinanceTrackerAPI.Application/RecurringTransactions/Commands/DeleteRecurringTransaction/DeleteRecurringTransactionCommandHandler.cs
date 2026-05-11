using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.RecurringTransactions.Commands.DeleteRecurringTransaction;

public class DeleteRecurringTransactionCommandHandler
{
  private readonly IRecurringTransactionRepository _recurringTransactionRepository;

  public DeleteRecurringTransactionCommandHandler(IRecurringTransactionRepository recurringTransactionRepository)
  {
    _recurringTransactionRepository = recurringTransactionRepository;
  }

  public async Task<Result<bool>> Handle(DeleteRecurringTransactionCommand command)
  {
    var recurringTransaction = await _recurringTransactionRepository.GetByIdAsync(command.Id);
    if (recurringTransaction is null)
      return Result<bool>.Failure(new DomainError("RecurringTransaction.NotFound", "Recurring transaction not found."));

    await _recurringTransactionRepository.DeleteAsync(recurringTransaction);
    return Result<bool>.Success(true);
  }
}
