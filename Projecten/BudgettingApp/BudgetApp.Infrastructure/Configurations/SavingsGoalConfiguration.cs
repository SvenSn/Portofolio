using BudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Infrastructure.Configurations;

public class SavingsGoalConfiguration : IEntityTypeConfiguration<SavingsGoal>
{
    public void Configure(EntityTypeBuilder<SavingsGoal> builder)
    {
        builder.ToTable("SavingsGoals", table =>
        {
            table.HasCheckConstraint(
                "CK_SavingsGoals_TargetAmount_Positive",
                "\"TargetAmount\" > 0");

            table.HasCheckConstraint(
                "CK_SavingsGoals_CurrentAmount_NonNegative",
                "\"CurrentAmount\" >= 0");
        });

        builder.HasKey(s => s.Id);
        builder.HasOne<Account>().WithMany().HasForeignKey(s => s.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.TargetAmount)
            .IsRequired()
            .HasConversion(
                amount => decimal.ToInt64(amount * 100m),
                cents => cents / 100m);

        builder.Property(s => s.CurrentAmount)
            .IsRequired()
            .HasConversion(
                amount => decimal.ToInt64(amount * 100m),
                cents => cents / 100m);

        builder.Property(s => s.TargetDate)
            .IsRequired();

        builder.Ignore(s => s.IsCompleted);
    }
}
