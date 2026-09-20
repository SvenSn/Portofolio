using BudgetApp.Domain.Models;


namespace BudgetApp.Domain.Interfaces.Services;

public interface IMonthlyFinanceService
{
    Task<MonthlySummary> GetSummaryAsync(int year, int month, int? accountId = null);

    Task<MonthlySummary> GetCurrentMonthSummaryAsync(int? accountId = null);
}
