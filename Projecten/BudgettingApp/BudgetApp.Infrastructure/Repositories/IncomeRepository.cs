using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Infrastructure.Repositories;

public class IncomeRepository : IIncomeRepository
{
    private readonly IDbContextFactory<BudgetDbContext> _contextFactory;

    public IncomeRepository(IDbContextFactory<BudgetDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Income> AddAsync(Income income)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await context.Incomes.AddAsync(income);
        await context.SaveChangesAsync();

        return income;
    }

    public async Task DeleteAsync(Income income)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await context.Incomes.AsNoTracking().Where(i => i.Id == income.Id).ExecuteDeleteAsync();
    }

    public async Task<IReadOnlyList<Income>> GetAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Incomes.AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<Income>> GetByAccountIdAsync(int accountId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Incomes.AsNoTracking().Where(i => i.AccountId == accountId).ToListAsync();
    }

    public async Task<Income?> GetByIdAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Incomes.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Income?> GetEffectiveIncomeAsync(DateTime date)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Incomes
            .Where(i => i.EffectiveFrom <= date)
            .OrderByDescending(i => i.EffectiveFrom)
            .FirstOrDefaultAsync();
    }

    public async Task<Income> UpdateAsync(Income income)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        context.Incomes.Update(income);
        await context.SaveChangesAsync();

        return income;
    }
}
