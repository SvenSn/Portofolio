using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Models;

namespace BudgetApp.App.ViewModels;

public sealed record ExpenseSlice(CategoryType Category, decimal Amount, decimal Share, Color Color)
{
    public static ExpenseSlice From(ExpenseCategorySummary category, decimal total) =>
        new(category.Category, category.Amount, total > 0 ? category.Amount / total : 0m,
            Color.FromArgb(category.Category switch
            {
                CategoryType.Housing => "#818CF8",
                CategoryType.Transportation => "#38BDF8",
                CategoryType.Food => "#34D399",
                CategoryType.Utilities => "#FBBF24",
                CategoryType.Salary => "#A3E635",
                CategoryType.Entertainment => "#F472B6",
                CategoryType.Subscriptions => "#C084FC",
                CategoryType.Healthcare => "#FB7185",
                _ => "#94A3B8"
            }));
}
