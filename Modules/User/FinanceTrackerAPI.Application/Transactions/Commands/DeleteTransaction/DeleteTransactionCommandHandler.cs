using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Transactions.Commands.DeleteTransaction;

public class DeleteTransactionCommandHandler
{
  private readonly ITransactionRepository _transactionRepository;

  public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
  {
    _transactionRepository = transactionRepository;
  }

  public async Task<Result<bool>> Handle(DeleteTransactionCommand command)
  {
    var transaction = await _transactionRepository.GetByIdAsync(command.Id);
    if (transaction is null)
      return Result<bool>.Failure(new DomainError("Transaction.NotFound", "Transaction not found."));

    await _transactionRepository.DeleteAsync(transaction);
    return Result<bool>.Success(true);
  }
}
