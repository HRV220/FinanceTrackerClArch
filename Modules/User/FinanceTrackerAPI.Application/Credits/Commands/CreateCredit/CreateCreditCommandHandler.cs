using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Credits.Commands.CreateCredit;

public class CreateCreditCommandHandler
{
  private readonly ICreditRepository _creditRepository;
  private readonly IProfileRepository _profileRepository;
  private readonly ICurrencyRepository _currencyRepository;

  public CreateCreditCommandHandler(ICreditRepository creditRepository, IProfileRepository profileRepository, ICurrencyRepository currencyRepository)
  {
    _creditRepository = creditRepository;
    _profileRepository = profileRepository;
    _currencyRepository = currencyRepository;
  }

  public async Task<Result<Guid>> Handle(CreateCreditCommand command)
  {
    var profile = await _profileRepository.GetByIdProfileAsync(command.ProfileId);
    if (profile is null)
      return Result<Guid>.Failure(new DomainError("Credit.ProfileNotFound", "Profile not found."));

    var currency = await _currencyRepository.GetByIdAsync(command.CurrencyId);
    if (currency is null)
      return Result<Guid>.Failure(new DomainError("Credit.CurrencyNotFound", "Currency not found."));

    var (profileId, currencyId, name, totalAmount, monthlyPayment, interestRate, startDate, endDate) = command;
    var credit = Credit.Create(profileId, currencyId, name, totalAmount, monthlyPayment, interestRate, startDate, endDate);

    if (credit.IsFailure)
      return Result<Guid>.Failure(credit.Error!);

    await _creditRepository.CreateAsync(credit.Value!);
    return Result<Guid>.Success(credit.Value!.Id);
  }
}
