using FinanceTrackerAPI.Domain.Enums;

namespace FinanceTrackerAPI.Application.Categories.Queries.GetCategoriesByProfileId;

public record GetCategoriesByProfileIdResponse(
  Guid Id,
  string Name,
  CategoryType Type,
  string? Icon,
  bool IsSystem,
  Guid? ProfileId);
