using FinanceTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTrackerAPI.Infrastructure.Persistence.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
  public void Configure(EntityTypeBuilder<Currency> builder)
  {
    builder.HasKey(c => c.Id);
    builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
    builder.Property(c => c.Nominal).IsRequired();
    builder.Property(c => c.Rate).HasColumnType("decimal(18,4)").IsRequired();
    builder.Property(c => c.NumericCode).IsRequired().HasMaxLength(10);
    builder.Property(c => c.Code).IsRequired().HasMaxLength(10);
    builder.HasIndex(c => c.Code).IsUnique();
    builder.HasIndex(c => c.NumericCode).IsUnique();
    builder.Property(c => c.UnitRate).HasColumnType("decimal(18,4)").IsRequired();
    builder.HasMany(c => c.Wallets).WithOne(w => w.Currency).HasForeignKey(w => w.CurrencyId);
  }
}
