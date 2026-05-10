namespace FinanceTrackerAPI.Application.Categories.Commands.ChangeIcon;

public record ChangeIconCategoryCommand(Guid Id, string? NewIcon);
