using FinanceTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Infrastructure.Persistence;
public class AppDbContext : DbContext
{
  public DbSet<User> Users {get;set;}
  public DbSet<Profile> Profiles {get; set;}
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
  }
}