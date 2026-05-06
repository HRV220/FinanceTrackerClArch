namespace FinanceTrackerAPI.Application.Wallets.Commands.ChangeSortOrder;

public record ChangeSortOrderCommand(Guid Id, int NewSortOrder);
