using FinanceTrackerAPI.Domain.Interfaces;
using FinanceTrackerAPI.Domain.Common;


namespace FinanceTrackerAPI.Application.Profiles.Queries.GetProfilesByUserId;
public class GetProfilesByUserIdQueryHandler
{
  private readonly IProfileRepository _profileRepository;

  public GetProfilesByUserIdQueryHandler(IProfileRepository profileRepository)
  {
    _profileRepository = profileRepository;
  }

  public async Task<Result<IEnumerable<GetProfilesByUserIdResponse>>> Handle(GetProfilesByUserIdQuery query)
  {
    var profiles = await _profileRepository.GetByUserIdProfilesAsync(query.UserId);
    var response = profiles.Select(p => new GetProfilesByUserIdResponse(p.Id, p.Name, p.IsActive));
    return Result<IEnumerable<GetProfilesByUserIdResponse>>.Success(response);
  }
}