using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(Guid ProfileId, string Name, FinancialType Type, string? Icon = null);
