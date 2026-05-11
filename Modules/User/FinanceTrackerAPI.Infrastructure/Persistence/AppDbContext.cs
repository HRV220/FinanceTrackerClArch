using FinanceTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Infrastructure.Persistence;
public class AppDbContext : DbContext
{
  public DbSet<User> Users {get;set;}
  public DbSet<Profile> Profiles {get; set;}
  public DbSet<Wallet> Wallets {get; set;}
  public DbSet<Currency> Currencies {get; set;}
  public DbSet<Unit> Units {get; set;}
  public DbSet<Credit> Credits {get; set;}
  public DbSet<Debt> Debts {get; set;}
  public DbSet<Deposit> Deposits {get; set;}
  public DbSet<Category> Categories {get; set;}
  public DbSet<Transaction> Transactions {get; set;}
  public DbSet<RecurringTransaction> RecurringTransactions {get; set;}
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
  }
}