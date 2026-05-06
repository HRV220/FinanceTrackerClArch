using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;
using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Application.Wallets.Commands.ChangeCurrency;

public class ChangeCurrencyCommandHandler
{
  private readonly IWalletRepository _walletRepository;

  public ChangeCurrencyCommandHandler(IWalletRepository walletRepository)
  {
    _walletRepository = walletRepository;
  }

  public async Task<Result<bool>> Handle(ChangeCurrencyCommand command)
  {
    var wallet = await _walletRepository.GetWalletByIdAsync(command.Id);
    if (wallet is null)
      return Result<bool>.Failure(new DomainError("Wallet.NotFound", "Wallet not found."));

    var currency = Currency.Create(command.NewCurrency);
    wallet.ChangeCurrency(currency.Value!);
    await _walletRepository.UpdateAsync(wallet);
    return Result<bool>.Success(true);
  }
}
