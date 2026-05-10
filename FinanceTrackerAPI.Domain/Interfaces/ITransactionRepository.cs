using FinanceTrackerAPI.Domain.Entities;

namespace FinanceTrackerAPI.Domain.Interfaces;

public interface ITransactionRepository
{
  Task CreateAsync(Transaction transaction);
  Task<Transaction?> GetByIdAsync(Guid id);
  Task<IEnumerable<Transaction>> GetByWalletIdAsync(Guid walletId);
  Task UpdateAsync(Transaction transaction);
  Task DeleteAsync(Transaction transaction);
}
