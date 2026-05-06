using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Interfaces;
using FinanceTrackerAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Infrastructure.Persistence.Repositories;

public class ProfileRepository : IProfileRepository
{
  private readonly AppDbContext _context;

  public ProfileRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task AddProfileAsync(Profile profile)
  {
    _context.Profiles.Add(profile);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(Profile profile)
  {
    _context.Profiles.Remove(profile);
    await _context.SaveChangesAsync();
  }

  public async Task<Profile?> GetByIdProfileAsync(Guid id)
  {
    return await _context.Profiles.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
  }

  public async Task<IEnumerable<Profile>> GetByUserIdProfilesAsync(Guid userId)
  {
    return await _context.Profiles.AsNoTracking().Where(p => p.UserId == userId).ToListAsync();
  }

  public async Task UpdateProfileAsync(Profile profile)
  {
    await _context.Profiles
      .Where(p => p.Id == profile.Id)
      .ExecuteUpdateAsync(s => s
        .SetProperty(p => p.Name, profile.Name)
        .SetProperty(p => p.IsActive, profile.IsActive)
        .SetProperty(p => p.UpdatedAt, DateTime.UtcNow));
  }
}