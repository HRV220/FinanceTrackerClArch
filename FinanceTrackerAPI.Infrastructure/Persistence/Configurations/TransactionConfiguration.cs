using FinanceTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTrackerAPI.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
  public void Configure(EntityTypeBuilder<Transaction> builder)
  {
    builder.HasKey(t => t.Id);
    builder.Property(t => t.Amount).HasColumnType("decimal(18,2)");
    builder.Property(t => t.Type).IsRequired();
    builder.Property(t => t.Date).IsRequired();
    builder.Property(t => t.Description).IsRequired(false).HasMaxLength(500);
    builder.Property(t => t.CategoryId).IsRequired(false);
    builder.HasOne(t => t.Wallet).WithMany(w => w.Transactions).HasForeignKey(t => t.WalletId);
    builder.HasOne(t => t.Category).WithMany().HasForeignKey(t => t.CategoryId).IsRequired(false);
  }
}
