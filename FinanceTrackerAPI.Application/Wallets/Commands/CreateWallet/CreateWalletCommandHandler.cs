using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;
using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Application.Wallets.Commands.CreateWallet;

public class CreateWalletCommandHandler
{
  private readonly IWalletRepository _walletRepository;
  private readonly IProfileRepository _profileRepository;

  public CreateWalletCommandHandler(IWalletRepository walletRepository, IProfileRepository profileRepository)
  {
    _walletRepository = walletRepository;
    _profileRepository = profileRepository;
  }

  public async Task<Result<Guid>> Handle(CreateWalletCommand command)
  {
    var profile = await _profileRepository.GetByIdProfileAsync(command.ProfileId);
    if (profile is null)
      return Result<Guid>.Failure(new DomainError("Wallet.ProfileNotFound", "Profile not found."));

    var currency = Currency.Create(command.Currency);

    var wallet = Wallet.Create(
      command.ProfileId,
      command.Name,
      command.SortOrder,
      currency.Value!,
      command.InitialBalance,
      command.Icon,
      command.Note);

    if (wallet.IsFailure)
      return Result<Guid>.Failure(wallet.Error!);

    await _walletRepository.CreateAsync(wallet.Value!);
    return Result<Guid>.Success(wallet.Value!.Id);
  }
}
