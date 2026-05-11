namespace FinanceTrackerAPI.Application.Profiles.Commands.CreateProfile;

public record CreateProfileCommand(Guid UserId, string Name);

