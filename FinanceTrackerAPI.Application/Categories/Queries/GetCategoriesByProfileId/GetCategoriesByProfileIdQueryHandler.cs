using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Categories.Queries.GetCategoriesByProfileId;

public class GetCategoriesByProfileIdQueryHandler
{
  private readonly ICategoryRepository _categoryRepository;

  public GetCategoriesByProfileIdQueryHandler(ICategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<Result<IEnumerable<GetCategoriesByProfileIdResponse>>> Handle(GetCategoriesByProfileIdQuery query)
  {
    var categories = await _categoryRepository.GetByProfileIdAsync(query.ProfileId);

    var response = categories.Select(c => new GetCategoriesByProfileIdResponse(
      c.Id, c.Name, c.Type, c.Icon, c.IsSystem, c.ProfileId));

    return Result<IEnumerable<GetCategoriesByProfileIdResponse>>.Success(response);
  }
}
