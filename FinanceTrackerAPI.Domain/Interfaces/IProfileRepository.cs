namespace FinanceTrackerAPI.Domain;
public interface IProfileRepository
{
  Task<Profile?> GetByIdProfileAsync(Guid id);
  Task<List<Profile>> GetByUserIdProfilesAsync(Guid userId);
  Task DeleteAsync(Guid id);
  Task UpdateProfileAsync(Profile profile);
  Task AddProfileAsync(Profile profile);
}