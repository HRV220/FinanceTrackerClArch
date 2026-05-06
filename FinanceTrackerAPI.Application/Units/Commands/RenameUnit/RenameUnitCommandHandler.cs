using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Units.Commands.RenameUnit;

public class RenameUnitCommandHandler
{
  private readonly IUnitRepository _unitRepository;

  public RenameUnitCommandHandler(IUnitRepository unitRepository)
  {
    _unitRepository = unitRepository;
  }

  public async Task<Result<bool>> Handle(RenameUnitCommand command)
  {
    var unit = await _unitRepository.GetByIdAsync(command.Id);
    if (unit is null)
      return Result<bool>.Failure(new DomainError("Unit.NotFound", "Unit not found."));

    unit.Rename(command.Name, command.ShortName);
    await _unitRepository.UpdateAsync(unit);
    return Result<bool>.Success(true);
  }
}
