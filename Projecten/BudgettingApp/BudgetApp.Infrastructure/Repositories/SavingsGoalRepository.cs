using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Repositories;

public class SavingsGoalRepository : ISavingsGoalRepository
{

    private readonly IDbContextFactory<BudgetDbContext> _contextFactory;

    public SavingsGoalRepository(IDbContextFactory<BudgetDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<SavingsGoal> AddAsync(SavingsGoal savingsGoal)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await context.SavingsGoals.AddAsync(savingsGoal);
        await context.SaveChangesAsync();

        return savingsGoal;
         
    }

    public async Task DeleteAsync(SavingsGoal savingsGoal)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await context.SavingsGoals.AsNoTracking().Where(sg => sg.Id == savingsGoal.Id).ExecuteDeleteAsync();
    }

    public async Task<IReadOnlyList<SavingsGoal>> GetAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.SavingsGoals.AsNoTracking().ToListAsync();
    }

    public async Task<SavingsGoal?> GetByIdAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.SavingsGoals.AsNoTracking().FirstOrDefaultAsync(sg => sg.Id == id);
    }

    public async Task<IReadOnlyList<SavingsGoal>> GetByAccountIdAsync(int accountId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.SavingsGoals.AsNoTracking()
            .Where(goal => goal.AccountId == accountId).ToListAsync();
    }

    public async Task<SavingsGoal> UpdateAsync(SavingsGoal savingsGoal)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        context.SavingsGoals.Update(savingsGoal);
        await context.SaveChangesAsync();
        return savingsGoal;
    }
}
