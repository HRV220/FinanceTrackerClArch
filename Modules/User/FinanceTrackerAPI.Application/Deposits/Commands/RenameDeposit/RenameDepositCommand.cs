namespace FinanceTrackerAPI.Application.Deposits.Commands.RenameDeposit;

public record RenameDepositCommand(Guid Id, string NewName);
