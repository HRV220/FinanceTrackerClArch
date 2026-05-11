using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Debts.Commands.CreateDebt;

public class CreateDebtCommandHandler
{
  private readonly IDebtRepository _debtRepository;
  private readonly IProfileRepository _profileRepository;
  private readonly ICurrencyRepository _currencyRepository;

  public CreateDebtCommandHandler(IDebtRepository debtRepository, IProfileRepository profileRepository, ICurrencyRepository currencyRepository)
  {
    _debtRepository = debtRepository;
    _profileRepository = profileRepository;
    _currencyRepository = currencyRepository;
  }

  public async Task<Result<Guid>> Handle(CreateDebtCommand command)
  {
    var profile = await _profileRepository.GetByIdProfileAsync(command.ProfileId);
    if (profile is null)
      return Result<Guid>.Failure(new DomainError("Debt.ProfileNotFound", "Profile not found."));

    var currency = await _currencyRepository.GetByIdAsync(command.CurrencyId);
    if (currency is null)
      return Result<Guid>.Failure(new DomainError("Debt.CurrencyNotFound", "Currency not found."));

    var (profileId, currencyId, creditorName, totalAmount, dueDate) = command;
    var debt = Debt.Create(profileId, currencyId, creditorName, totalAmount, dueDate);

    if (debt.IsFailure)
      return Result<Guid>.Failure(debt.Error!);

    await _debtRepository.CreateAsync(debt.Value!);
    return Result<Guid>.Success(debt.Value!.Id);
  }
}
