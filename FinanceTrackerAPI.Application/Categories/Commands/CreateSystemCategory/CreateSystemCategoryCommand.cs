using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Categories.Commands.CreateSystemCategory;

public record CreateSystemCategoryCommand(string Name, FinancialType Type, string? Icon = null);
