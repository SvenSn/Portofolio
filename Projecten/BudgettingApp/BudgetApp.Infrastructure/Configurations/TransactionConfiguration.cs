using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Configurations;

public class TransactionConfiguration
    : IEntityTypeConfiguration<Domain.Entities.Transaction>
{
    public void Configure(
        EntityTypeBuilder<Domain.Entities.Transaction> builder)
    {
        builder.ToTable("Transactions", table =>
        {
            table.HasCheckConstraint(
                "CK_Transactions_Amount_Positive",
                "\"Amount\" > 0");
        });

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Amount)
            .IsRequired()
            .HasConversion(
                amount => decimal.ToInt64(amount * 100m),
                cents => cents / 100m);

        builder.Property(t => t.Date)
            .IsRequired();

        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Type)
            .IsRequired();

        builder.Property(t => t.Category)
            .IsRequired();

        builder.Property(t => t.AccountId)
            .IsRequired();

        builder.HasIndex(t => t.Date);

        builder.HasOne<Account>()
            .WithMany()
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}