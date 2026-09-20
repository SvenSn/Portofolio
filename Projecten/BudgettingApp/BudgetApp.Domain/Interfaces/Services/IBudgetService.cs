using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Domain.Interfaces.Services;

public interface IBudgetService
{
    Task<Budget> CreateAsync(
       CategoryType category,
       decimal amount,
       int month,
       int year, int accountId);

    Task<IReadOnlyList<Budget>> GetByAccountIdAsync(int accountId);
    Task AssignToAccountAsync(int budgetId, int accountId);

    Task<Budget?> GetByIdAsync(int id);

    Task<IReadOnlyList<Budget>> GetAllAsync();

    Task<Budget> UpdateAmountAsync(
        int budgetId,
        decimal newAmount);

    Task DeleteAsync(int budgetId);
}
