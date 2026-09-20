namespace BudgetApp.Domain.Models;

public sealed class MonthlySummary
{
    public int Year { get; }

    public int Month { get; }

    public decimal Income { get; }

    public decimal Expenses { get; }

    public decimal Remaining => Income - Expenses;
    public IReadOnlyList<ExpenseCategorySummary> ExpenseCategories { get; }

    public MonthlySummary(
        int year,
        int month,
        decimal income,
        decimal expenses,
        IReadOnlyList<ExpenseCategorySummary>? expenseCategories = null)
    {
        if (month is < 1 or > 12)
            throw new ArgumentOutOfRangeException(
                nameof(month),
                "Maand moet tussen 1 en 12 liggen.");

        if (year < 2000)
            throw new ArgumentOutOfRangeException(
                nameof(year),
                "Jaar is ongeldig.");

        if (income < 0)
            throw new ArgumentOutOfRangeException(
                nameof(income),
                "Inkomen mag niet negatief zijn.");

        if (expenses < 0)
            throw new ArgumentOutOfRangeException(
                nameof(expenses),
                "Uitgaven mogen niet negatief zijn.");

        Year = year;
        Month = month;
        Income = income;
        Expenses = expenses;
        ExpenseCategories = expenseCategories ?? [];
    }
}
