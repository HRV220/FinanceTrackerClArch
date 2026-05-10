using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler
{
  private readonly ICategoryRepository _categoryRepository;
  private readonly IProfileRepository _profileRepository;

  public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IProfileRepository profileRepository)
  {
    _categoryRepository = categoryRepository;
    _profileRepository = profileRepository;
  }

  public async Task<Result<Guid>> Handle(CreateCategoryCommand command)
  {
    var profile = await _profileRepository.GetByIdProfileAsync(command.ProfileId);
    if (profile is null)
      return Result<Guid>.Failure(new DomainError("Category.ProfileNotFound", "Profile not found."));

    var (profileId, name, type, icon) = command;
    var category = Category.Create(name, type, profileId, icon);

    if (category.IsFailure)
      return Result<Guid>.Failure(category.Error!);

    await _categoryRepository.CreateAsync(category.Value!);
    return Result<Guid>.Success(category.Value!.Id);
  }
}
