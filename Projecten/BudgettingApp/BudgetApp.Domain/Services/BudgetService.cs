using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Domain.Interfaces.Services;

namespace BudgetApp.Domain.Services;

public class BudgetService(IBudgetRepository budgetRepository) : IBudgetService
{
    public async Task<Budget> CreateAsync(CategoryType category, decimal amount, int month, int year, int accountId)
    {
        Budget budget = new Budget(category, amount, month, year);
        budget.AssignToAccount(accountId);

        return await budgetRepository.AddAsync(budget);
    }

    public async Task DeleteAsync(int budgetId)
    {
        var budget = await budgetRepository.GetByIdAsync(budgetId);

        if(budget is null)
        {
            throw new InvalidOperationException($"Budget with ID {budgetId} not found.");
        }

        await budgetRepository.DeleteAsync(budget);
    }

    public Task<IReadOnlyList<Budget>> GetByAccountIdAsync(int accountId)
        => budgetRepository.GetByAccountIdAsync(accountId);

    public async Task AssignToAccountAsync(int budgetId, int accountId)
    {
        var budget = await budgetRepository.GetByIdAsync(budgetId)
            ?? throw new ArgumentException("Budget not found.");
        budget.AssignToAccount(accountId);
        await budgetRepository.UpdateAsync(budget);
    }

    public async Task<IReadOnlyList<Budget>> GetAllAsync()
    {
        return await budgetRepository.GetAllAsync();
    }

    public async Task<Budget?> GetByIdAsync(int id)
    {
        var budget = await budgetRepository.GetByIdAsync(id);

        if(budget is null)
        {
            throw new InvalidOperationException($"Budget with ID {id} not found.");
        }

        return budget;
    }

    public async Task<Budget> UpdateAmountAsync(int budgetId, decimal newAmount)
    {
        var budget = await budgetRepository.GetByIdAsync(budgetId);

        if (budget is null)
        {
            throw new InvalidOperationException($"Budget with ID {budgetId} not found.");
        }

        budget.UpdateAmount(newAmount);

        return await budgetRepository.UpdateAsync(budget);

    }
}
