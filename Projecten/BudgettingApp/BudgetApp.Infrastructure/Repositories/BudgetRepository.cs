using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Repositories;

public class BudgetRepository : IBudgetRepository
{
    private readonly IDbContextFactory<BudgetDbContext> _contextFactory;

    public BudgetRepository(IDbContextFactory<BudgetDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Budget> AddAsync(Budget budget)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await context.Budgets.AddAsync(budget);
        await context.SaveChangesAsync();

        return budget;
    }

    public async Task DeleteAsync(Budget budget)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await context.Budgets.AsNoTracking().Where(b => b.Id == budget.Id).ExecuteDeleteAsync();  
    }

    public async Task<IReadOnlyList<Budget>> GetAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

       return await context.Budgets.AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<Budget>> GetByAccountIdAsync(int accountId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Budgets.AsNoTracking().Where(b => b.AccountId == accountId).ToListAsync();
    }

    public async Task<Budget?> GetByIdAsync(int budgetId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Budgets.AsNoTracking().FirstOrDefaultAsync(b => b.Id == budgetId);
    }

    public async Task<Budget> UpdateAsync(Budget budget)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        context.Budgets.Update(budget);
        await context.SaveChangesAsync();

        return budget;
    }
}
