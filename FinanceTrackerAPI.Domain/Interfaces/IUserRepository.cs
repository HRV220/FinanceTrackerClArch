using FinanceTrackerAPI.Domain;

public interface IUserRepository
{
  Task<User?> GetByIdAsync(Guid id);
  Task<User?> GetByEmailAsync(Email email);
  Task AddUserAsync(User user);
  Task UpdateUserAsync(User user);
  Task DeleteUserAsync(Guid id);
}