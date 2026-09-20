using BudgetApp.Domain.Entities;


namespace BudgetApp.Domain.Interfaces.Services;

public interface IIncomeService
{
    Task<Income> CreateAsync(
    decimal amount,
    DateTime effectiveFrom, int accountId);

    Task<IReadOnlyList<Income>> GetByAccountIdAsync(int accountId);
    Task EnsureMonthlyTransactionAsync(int accountId, DateTime month);
    Task AssignToAccountAsync(int incomeId, int accountId);

    Task<Income?> GetByIdAsync(int id);

    Task<IReadOnlyList<Income>> GetAllAsync();

    Task<Income?> GetEffectiveIncomeAsync(DateTime date);

    Task<Income> UpdateAmountAsync(
        int incomeId,
        decimal newAmount);

    Task<Income> UpdateEffectiveFromAsync(
        int incomeId,
        DateTime effectiveFrom);

    Task DeleteAsync(int incomeId);
}
