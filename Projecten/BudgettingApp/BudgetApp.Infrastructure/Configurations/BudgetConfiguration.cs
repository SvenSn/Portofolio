using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Infrastructure.Configurations;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable("Budgets", table =>
        {
            table.HasCheckConstraint(
                "CK_Budgets_Amount_Positive",
                "\"Amount\" > 0");
        });

        builder.HasKey(b => b.Id);
        builder.HasOne<Account>().WithMany().HasForeignKey(b => b.AccountId).OnDelete(DeleteBehavior.Restrict);

        builder.Property(b => b.Category)
            .IsRequired();

        builder.Property(b => b.Amount)
            .IsRequired()
            .HasConversion(
                amount => decimal.ToInt64(amount * 100m),
                cents => cents / 100m);

        builder.Property(b => b.Month)
            .IsRequired();

        builder.Property(b => b.Year)
            .IsRequired();



    }
}
