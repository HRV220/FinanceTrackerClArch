using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Units.Commands.CreateUnit;

public class CreateUnitCommandHandler
{
  private readonly IUnitRepository _unitRepository;
  private readonly IProfileRepository _profileRepository;

  public CreateUnitCommandHandler(IUnitRepository unitRepository, IProfileRepository profileRepository)
  {
    _unitRepository = unitRepository;
    _profileRepository = profileRepository;
  }

  public async Task<Result<Guid>> Handle(CreateUnitCommand command)
  {
    var profile = await _profileRepository.GetByIdProfileAsync(command.ProfileId);
    if (profile is null)
      return Result<Guid>.Failure(new DomainError("Unit.ProfileNotFound", "Profile not found."));

    var unit = Unit.Create(command.Name, command.ShortName, command.ProfileId);
    if (unit.IsFailure)
      return Result<Guid>.Failure(unit.Error!);

    await _unitRepository.AddAsync(unit.Value!);
    return Result<Guid>.Success(unit.Value!.Id);
  }
}
