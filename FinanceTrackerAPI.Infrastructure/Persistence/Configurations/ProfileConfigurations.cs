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
  }
}