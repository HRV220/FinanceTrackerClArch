using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Transactions.Commands.CreateTransaction;

public class CreateTransactionCommandHandler
{
  private readonly ITransactionRepository _transactionRepository;
  private readonly IWalletRepository _walletRepository;

  public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IWalletRepository walletRepository)
  {
    _transactionRepository = transactionRepository;
    _walletRepository = walletRepository;
  }

  public async Task<Result<Guid>> Handle(CreateTransactionCommand command)
  {
    var wallet = await _walletRepository.GetWalletByIdAsync(command.WalletId);
    if (wallet is null)
      return Result<Guid>.Failure(new DomainError("Transaction.WalletNotFound", "Wallet not found."));

    if (command.ToWalletId.HasValue)
    {
      var toWallet = await _walletRepository.GetWalletByIdAsync(command.ToWalletId.Value);
      if (toWallet is null)
        return Result<Guid>.Failure(new DomainError("Transaction.DestinationWalletNotFound", "Destination wallet not found."));
    }

    var (walletId, type, amount, date, categoryId, description, toWalletId) = command;
    var transaction = Transaction.Create(walletId, type, amount, date, categoryId, description, toWalletId);

    if (transaction.IsFailure)
      return Result<Guid>.Failure(transaction.Error!);

    await _transactionRepository.CreateAsync(transaction.Value!);
    return Result<Guid>.Success(transaction.Value!.Id);
  }
}
