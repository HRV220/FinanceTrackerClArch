using FinanceTrackerAPI.Domain.Entities;

namespace FinanceTrackerAPI.Domain.Interfaces;

public interface ICreditRepository
{
  Task CreateAsync(Credit credit);
  Task<Credit?> GetByIdAsync(Guid id);
  Task<IEnumerable<Credit>> GetByProfileIdAsync(Guid profileId);
  Task UpdateAsync(Credit credit);
  Task DeleteAsync(Credit credit);
}
