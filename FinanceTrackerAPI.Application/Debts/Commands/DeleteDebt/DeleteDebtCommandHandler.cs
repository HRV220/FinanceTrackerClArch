using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Debts.Commands.DeleteDebt;

public class DeleteDebtCommandHandler
{
  private readonly IDebtRepository _debtRepository;

  public DeleteDebtCommandHandler(IDebtRepository debtRepository)
  {
    _debtRepository = debtRepository;
  }

  public async Task<Result<bool>> Handle(DeleteDebtCommand command)
  {
    var debt = await _debtRepository.GetByIdAsync(command.Id);
    if (debt is null)
      return Result<bool>.Failure(new DomainError("Debt.NotFound", "Debt not found."));

    await _debtRepository.DeleteAsync(debt);
    return Result<bool>.Success(true);
  }
}
