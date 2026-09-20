using BudgetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Domain.Interfaces.Repositories;

public interface IBudgetRepository
{
    Task<IReadOnlyList<Budget>> GetByAccountIdAsync(int accountId);
    Task<Budget?> GetByIdAsync(int budgetId);
    Task<IReadOnlyList<Budget>> GetAllAsync();
    Task<Budget> AddAsync(Budget budget);
    Task<Budget> UpdateAsync(Budget budget);
    Task DeleteAsync(Budget budget);
}
