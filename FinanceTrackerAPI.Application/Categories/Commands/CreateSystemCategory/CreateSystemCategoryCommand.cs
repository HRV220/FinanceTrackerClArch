using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Categories.Commands.CreateSystemCategory;

public record CreateSystemCategoryCommand(string Name, CategoryType Type, string? Icon = null);
