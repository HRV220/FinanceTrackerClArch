using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdResponse(
  Guid Id,
  string Name,
  CategoryType Type,
  string? Icon,
  bool IsSystem,
  Guid? ProfileId);
