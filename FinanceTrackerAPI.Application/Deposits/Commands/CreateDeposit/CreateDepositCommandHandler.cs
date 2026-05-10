using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Deposits.Commands.CreateDeposit;

public class CreateDepositCommandHandler
{
  private readonly IDepositRepository _depositRepository;
  private readonly IProfileRepository _profileRepository;
  private readonly ICurrencyRepository _currencyRepository;

  public CreateDepositCommandHandler(IDepositRepository depositRepository, IProfileRepository profileRepository, ICurrencyRepository currencyRepository)
  {
    _depositRepository = depositRepository;
    _profileRepository = profileRepository;
    _currencyRepository = currencyRepository;
  }

  public async Task<Result<Guid>> Handle(CreateDepositCommand command)
  {
    var profile = await _profileRepository.GetByIdProfileAsync(command.ProfileId);
    if (profile is null)
      return Result<Guid>.Failure(new DomainError("Deposit.ProfileNotFound", "Profile not found."));

    var currency = await _currencyRepository.GetByIdAsync(command.CurrencyId);
    if (currency is null)
      return Result<Guid>.Failure(new DomainError("Deposit.CurrencyNotFound", "Currency not found."));

    var (profileId, currencyId, name, initialAmount, interestRate, startDate, endDate, isCapitalized) = command;
    var deposit = Deposit.Create(profileId, currencyId, name, initialAmount, interestRate, startDate, endDate, isCapitalized);

    if (deposit.IsFailure)
      return Result<Guid>.Failure(deposit.Error!);

    await _depositRepository.CreateAsync(deposit.Value!);
    return Result<Guid>.Success(deposit.Value!.Id);
  }
}
