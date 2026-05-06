namespace FinanceTrackerAPI.Application.Wallets.Commands.RenameWallet;

public record RenameWalletCommand(Guid Id, string NewName);
