using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Wallets.Commands.CreateWallet;

public class CreateWalletCommandHandler
{
  private readonly IWalletRepository _walletRepository;
  private readonly IProfileRepository _profileRepository;
  private readonly ICurrencyRepository _currencyRepository;

  public CreateWalletCommandHandler(IWalletRepository walletRepository, IProfileRepository profileRepository, ICurrencyRepository currencyRepository)
  {
    _walletRepository = walletRepository;
    _profileRepository = profileRepository;
    _currencyRepository = currencyRepository;
  }

  public async Task<Result<Guid>> Handle(CreateWalletCommand command)
  {
    var profile = await _profileRepository.GetByIdProfileAsync(command.ProfileId);
    if (profile is null)
      return Result<Guid>.Failure(new DomainError("Wallet.ProfileNotFound", "Profile not found."));

    var currency = await _currencyRepository.GetByIdAsync(command.CurrencyId);
    if (currency is null)
      return Result<Guid>.Failure(new DomainError("Wallet.CurrencyNotFound", "Currency not found."));

    var wallet = Wallet.Create(
      command.ProfileId,
      command.Name,
      command.SortOrder,
      command.CurrencyId,
      command.InitialBalance,
      command.Icon,
      command.Note);

    if (wallet.IsFailure)
      return Result<Guid>.Failure(wallet.Error!);

    await _walletRepository.CreateAsync(wallet.Value!);
    return Result<Guid>.Success(wallet.Value!.Id);
  }
}
