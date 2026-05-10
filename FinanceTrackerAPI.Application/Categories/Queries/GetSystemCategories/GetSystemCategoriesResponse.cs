using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Categories.Queries.GetSystemCategories;

public record GetSystemCategoriesResponse(Guid Id, string Name, CategoryType Type, string? Icon);
