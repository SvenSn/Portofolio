using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IDbContextFactory<BudgetDbContext> _contextFactory;

    public TransactionRepository(IDbContextFactory<BudgetDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Transaction> AddAsync(Transaction transaction)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await context.Transactions.AddAsync(transaction);
        var account = await context.Accounts.FindAsync(transaction.AccountId)
            ?? throw new InvalidOperationException("Rekening niet gevonden.");
        account.ApplyTransaction(transaction.Amount, transaction.Type);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task DeleteAsync(Transaction transaction)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var stored = await context.Transactions.FindAsync(transaction.Id)
            ?? throw new InvalidOperationException("Transactie niet gevonden.");
        var account = await context.Accounts.FindAsync(stored.AccountId)
            ?? throw new InvalidOperationException("Rekening niet gevonden.");
        var reverseType = stored.Type == BudgetApp.Domain.Enums.TransactionType.Income
            ? BudgetApp.Domain.Enums.TransactionType.Expense
            : BudgetApp.Domain.Enums.TransactionType.Income;
        account.ApplyTransaction(stored.Amount, reverseType);
        context.Transactions.Remove(stored);
        await context.SaveChangesAsync();

    }

    public async Task<IReadOnlyList<Transaction>> GetAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Transactions.AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<Transaction>> GetByAccountIdAsync(int accountId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Transactions
            .Where(t => t.AccountId == accountId)
            .ToListAsync();
    }

    public async Task<Transaction?> GetByIdAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Transactions.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateWithAccountAsync(Transaction transaction, Account account)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        // Beide wijzigingen worden in dezelfde databasetransactie opgeslagen.
        context.Transactions.Update(transaction);
        context.Accounts.Update(account);
        await context.SaveChangesAsync();
    }

    public async Task<Transaction> UpdateAsync(Transaction transaction)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        context.Transactions.Update(transaction);
        await context.SaveChangesAsync();  
        return transaction;
    }
}
