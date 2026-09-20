using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace BudgetApp.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{

    private readonly IDbContextFactory<BudgetDbContext> _contextFactory;

    public AccountRepository(IDbContextFactory<BudgetDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Account> AddAsync(Account account)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

         await context.Accounts.AddAsync(account);
         await context.SaveChangesAsync();

        return account;
  
    }

    public async Task DeleteAsync(Account account)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        // Delete all account-owned records atomically, after the UI confirmation.
        await using var transaction = await context.Database.BeginTransactionAsync();
        await context.Transactions.Where(t => t.AccountId == account.Id).ExecuteDeleteAsync();
        await context.SavingsGoals.Where(goal => goal.AccountId == account.Id).ExecuteDeleteAsync();
        await context.Incomes.Where(i => i.AccountId == account.Id).ExecuteDeleteAsync();
        await context.Budgets.Where(b => b.AccountId == account.Id).ExecuteDeleteAsync();
        await context.Accounts.Where(a => a.Id == account.Id).ExecuteDeleteAsync();
        await transaction.CommitAsync();
    }

    public async Task<IReadOnlyList<Account>> GetAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Accounts.AsNoTracking().ToListAsync();   
    }

    public async Task<Account?> GetByIdAsync(int accountId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Accounts.AsNoTracking().Where(a => a.Id == accountId).FirstOrDefaultAsync();
    }

    public async Task<Account> UpdateAsync(Account account)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

         context.Accounts.Update(account);
        await context.SaveChangesAsync();

        return account;
    }
}
