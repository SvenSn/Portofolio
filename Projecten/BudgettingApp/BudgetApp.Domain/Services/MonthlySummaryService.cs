using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Models;

namespace BudgetApp.Domain.Services;

public class MonthlyFinanceService(
    ITransactionService transactionService)
    : IMonthlyFinanceService
{
    public async Task<MonthlySummary> GetSummaryAsync(
        int year,
        int month, int? accountId = null)
    {
        if (year < 1 || year > 9999)
            throw new ArgumentOutOfRangeException(nameof(year));

        if (month is < 1 or > 12)
            throw new ArgumentOutOfRangeException(nameof(month));

        var transactions = accountId is { } id
            ? (await transactionService.GetByAccountIdAsync(id)).Where(t => t.Date.Year == year && t.Date.Month == month).ToList()
            : await transactionService.GetByMonthAsync(year, month);

        decimal income = 0m;
        decimal expenses = 0m;

        foreach (var transaction in transactions)
        {
            if (transaction.Type == TransactionType.Income)
            {
                income += transaction.Amount;
            }
            else if (transaction.Type == TransactionType.Expense)
            {
                expenses += transaction.Amount;
            }
        }

        return new MonthlySummary(
            year,
            month,
            income,
            expenses,
            transactions
                .Where(transaction => transaction.Type == TransactionType.Expense)
                .GroupBy(transaction => transaction.Category)
                .Select(group => new ExpenseCategorySummary(group.Key, group.Sum(transaction => transaction.Amount)))
                .OrderByDescending(category => category.Amount)
                .ThenBy(category => category.Category)
                .ToList());
    }

    public Task<MonthlySummary> GetCurrentMonthSummaryAsync(int? accountId = null)
    {
        var now = DateTime.Now;

        return GetSummaryAsync(
            now.Year,
            now.Month, accountId);
    }
}
