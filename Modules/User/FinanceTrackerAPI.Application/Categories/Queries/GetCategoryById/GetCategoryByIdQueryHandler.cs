using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler
{
  private readonly ICategoryRepository _categoryRepository;

  public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<Result<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery query)
  {
    var category = await _categoryRepository.GetByIdAsync(query.Id);
    if (category is null)
      return Result<GetCategoryByIdResponse>.Failure(new DomainError("Category.NotFound", "Category not found."));

    return Result<GetCategoryByIdResponse>.Success(new GetCategoryByIdResponse(
      category.Id,
      category.Name,
      category.Type,
      category.Icon,
      category.IsSystem,
      category.ProfileId));
  }
}
