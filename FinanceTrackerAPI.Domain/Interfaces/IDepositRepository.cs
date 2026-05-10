using FinanceTrackerAPI.Domain.Entities;

namespace FinanceTrackerAPI.Domain.Interfaces;

public interface IDepositRepository
{
  Task CreateAsync(Deposit deposit);
  Task<Deposit?> GetByIdAsync(Guid id);
  Task<IEnumerable<Deposit>> GetByProfileIdAsync(Guid profileId);
  Task UpdateAsync(Deposit deposit);
  Task DeleteAsync(Deposit deposit);
}
