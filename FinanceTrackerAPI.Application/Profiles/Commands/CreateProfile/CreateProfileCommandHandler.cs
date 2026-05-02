using FinanceTrackerAPI.Domain;
using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Application.Profiles.Commands.CreateProfile;
public class CreateProfileCommandHandler
{
  private readonly IProfileRepository _profileRepository;
  private readonly IUserRepository _userRepository;

  public CreateProfileCommandHandler(IProfileRepository profileRepository, IUserRepository userRepository)
  {
    _profileRepository = profileRepository;
    _userRepository = userRepository;
  }

  public async Task<Result<Guid>> Handle(CreateProfileCommand command)
  {
    //Проверка на несуществующего пользователя
    var existUser = await _userRepository.GetByIdAsync(command.UserId);
    if (existUser == null)
      return Result<Guid>.Failure(new DomainError("Profile.UserNotExist", "A non-existent user when creating a profile"));
    
    //Проверка на повторяющееся имя профиля
    var profileNames = await _profileRepository.GetByUserIdProfilesAsync(command.UserId);
    if (profileNames.Select(e => e.Name).Contains(command.Name))
      return Result<Guid>.Failure(new DomainError("Profile.ExistName", "This name already exists."));
   
    var currency = Currency.Create(command.Currency).Value!;

    var profile = Profile.Create(command.Name, currency, command.UserId);

    await _profileRepository.AddProfileAsync(profile);

    return Result<Guid>.Success(profile.Id);
  }
}