using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Transactions.Commands.ChangeDescription;

public class ChangeDescriptionCommandHandler
{
  private readonly ITransactionRepository _transactionRepository;

  public ChangeDescriptionCommandHandler(ITransactionRepository transactionRepository)
  {
    _transactionRepository = transactionRepository;
  }

  public async Task<Result<bool>> Handle(ChangeDescriptionCommand command)
  {
    var transaction = await _transactionRepository.GetByIdAsync(command.Id);
    if (transaction is null)
      return Result<bool>.Failure(new DomainError("Transaction.NotFound", "Transaction not found."));

    var result = transaction.ChangeDescription(command.NewDescription);
    if (result.IsFailure)
      return result;

    await _transactionRepository.UpdateAsync(transaction);
    return Result<bool>.Success(true);
  }
}
