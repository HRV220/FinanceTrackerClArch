using FinanceTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTrackerAPI.Infrastructure.Persistence.Configurations;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
  public void Configure(EntityTypeBuilder<Wallet> builder)
  {
    builder.HasKey(w => w.Id);
    builder.Property(w => w.Name).IsRequired().HasMaxLength(256);
    builder.Property(w => w.InitialBalance).HasColumnType("decimal(18,2)");
  }
}
