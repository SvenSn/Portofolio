using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetApp.Infrastructure.Configurations;

public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.ToTable("Incomes", table =>
        {
            table.HasCheckConstraint(
                "CK_Incomes_Amount_Positive",
                "\"Amount\" > 0");
        });

        builder.HasKey(i => i.Id);
        builder.HasOne<Account>().WithMany().HasForeignKey(i => i.AccountId).OnDelete(DeleteBehavior.Restrict);

        builder.Property(i => i.Amount)
            .IsRequired()
            .HasConversion(
                amount => decimal.ToInt64(amount * 100m),
                cents => cents / 100m);

        builder.Property(i => i.EffectiveFrom)
            .IsRequired();

    }
}
