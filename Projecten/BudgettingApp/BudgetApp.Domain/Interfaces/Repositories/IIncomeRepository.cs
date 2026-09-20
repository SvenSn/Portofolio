using BudgetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Domain.Interfaces.Repositories;

public interface IIncomeRepository
{
    Task<IReadOnlyList<Income>> GetByAccountIdAsync(int accountId);
    Task<Income?> GetByIdAsync(int id);

    Task<IReadOnlyList<Income>> GetAllAsync();

    Task<Income?> GetEffectiveIncomeAsync(DateTime date);

    Task<Income> AddAsync(Income income);

    Task<Income> UpdateAsync(Income income);

    Task DeleteAsync(Income income);
}
