using FinanceTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTrackerAPI.Infrastructure.Persistence.Configurations;
public class ProfileConfigurations : IEntityTypeConfiguration<Profile>
{
  public void Configure(EntityTypeBuilder<Profile> builder)
  {
    builder.HasKey(p => p.Id);
    builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
    builder.HasMany(p => p.Wallets).WithOne(w => w.Profile).HasForeignKey(w => w.ProfileId);
    builder.HasMany(p => p.Units).WithOne(u => u.Profile).HasForeignKey(u => u.ProfileId).IsRequired(false);
    builder.HasMany(p => p.Credits).WithOne(c => c.Profile).HasForeignKey(c => c.ProfileId);
    builder.HasMany(p => p.Debts).WithOne(d => d.Profile).HasForeignKey(d => d.ProfileId);
    builder.HasMany(p => p.Deposits).WithOne(d => d.Profile).HasForeignKey(d => d.ProfileId);
    builder.HasMany(p => p.Categories).WithOne(c => c.Profile).HasForeignKey(c => c.ProfileId).IsRequired(false);
  }
}