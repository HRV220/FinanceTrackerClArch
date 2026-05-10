using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(Guid ProfileId, string Name, CategoryType Type, string? Icon = null);
