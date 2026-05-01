using FinanceTrackerAPI.Domain;
using FinanceTrackerAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;
  public UserRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task AddUserAsync(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteUserAsync(Guid id)
  {
    var deleteUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    if (deleteUser is null) return;
    _context.Users.Remove(deleteUser!);
    await _context.SaveChangesAsync();
  }

  public async Task<User?> GetByEmailAsync(Email email)
  {
    return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
  }

  public async Task<User?> GetByIdAsync(Guid id)
  {
    return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);  
  }

  public async Task UpdateUserAsync(User user)
  {
    await _context.Users
      .Where(u => u.Id == user.Id)
      .ExecuteUpdateAsync(s => s
        .SetProperty(u => u.Email.Value, user.Email.Value)
        .SetProperty(u => u.PasswordHash.Value, user.PasswordHash.Value)
        .SetProperty(u => u.UpdatedAt, DateTime.UtcNow)
        );
  }
}