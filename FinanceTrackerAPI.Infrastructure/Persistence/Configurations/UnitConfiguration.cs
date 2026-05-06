using FinanceTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTrackerAPI.Infrastructure.Persistence.Configurations;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
  public void Configure(EntityTypeBuilder<Unit> builder)
  {
    builder.HasKey(u => u.Id);
    builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
    builder.Property(u => u.ShortName).IsRequired().HasMaxLength(20);
    builder.HasIndex(u => u.ShortName).IsUnique();
    builder.Property(u => u.IsSystem).IsRequired();
    builder.Property(u => u.ProfileId).IsRequired(false);
    builder.HasOne(u => u.Profile).WithMany(p => p.Units).HasForeignKey(u => u.ProfileId).IsRequired(false);
  }
}
