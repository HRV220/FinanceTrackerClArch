namespace FinanceTrackerAPI.Application.Transactions.Commands.ChangeCategory;

public record ChangeCategoryTransactionCommand(Guid Id, Guid? NewCategoryId);
