using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Domain.Interfaces;
public interface IUserRepository
{
  Task<User?> GetByIdAsync(Guid id);
  Task<User?> GetByEmailAsync(Email email);
  Task AddUserAsync(User user);
  Task UpdateUserAsync(User user);
  Task DeleteUserAsync(User user);
}