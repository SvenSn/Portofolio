

using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Domain.Interfaces.Services;

namespace BudgetApp.Domain.Services;

public class TransactionService(ITransactionRepository transactionRepository,IAccountRepository accountRepository) : ITransactionService
{
    public async Task<Transaction> CreateAsync(decimal amount, DateTime date, string description, TransactionType type, CategoryType category, int accountId)
    {
        Transaction transaction = new Transaction(amount, date, description, type, category, accountId);

        return await transactionRepository.AddAsync(transaction);
    }

    public async Task DeleteAsync(int transactionId)
    {
        var transaction = await transactionRepository.GetByIdAsync(transactionId);

        if (transaction == null)
        {
            throw new InvalidOperationException($"Transaction with ID {transactionId} not found.");
        }

        await transactionRepository.DeleteAsync(transaction);

    }

    public async Task<IReadOnlyList<Transaction>> GetAllAsync()
    {
        return await transactionRepository.GetAllAsync();
    }

    public async Task<IReadOnlyList<Transaction>> GetByAccountIdAsync(int accountId)
    {
        return await transactionRepository.GetByAccountIdAsync(accountId);
    }

    public async Task<Transaction?> GetByIdAsync(int id)
    {
        return await transactionRepository.GetByIdAsync(id);
    }

    public async Task<IReadOnlyList<Transaction>> GetByMonthAsync(int year, int month)
    {
        var transactions = await transactionRepository.GetAllAsync();

        return transactions
            .Where(t => t.Date.Year == year && t.Date.Month == month)
            .ToList();
    }

    public async Task<Transaction> UpdateAsync(
        int transactionId,
        decimal amount,
        DateTime date,
        string description,
        TransactionType type,
        CategoryType category)
    {
        var transaction = await transactionRepository.GetByIdAsync(transactionId);

        if (transaction is null)
            throw new InvalidOperationException("Transaction was not found.");

        var account = await accountRepository.GetByIdAsync(transaction.AccountId);

        if (account is null)
            throw new InvalidOperationException("Account was not found.");

        // 1. Draai het oude saldo-effect terug.
        var reverseType = transaction.Type == TransactionType.Income
            ? TransactionType.Expense
            : TransactionType.Income;

        account.ApplyTransaction(transaction.Amount, reverseType);

        // 2. Wijzig de transactie via de domeinmethodes.
        transaction.UpdateAmount(amount);
        transaction.UpdateDate(date);
        transaction.UpdateDescription(description);
        transaction.UpdateCategory(category);
        transaction.UpdateType(type);

        // 3. Pas het nieuwe saldo-effect toe.
        account.ApplyTransaction(transaction.Amount, transaction.Type);

        // 4. Sla de wijzigingen op.
        await transactionRepository.UpdateWithAccountAsync(transaction, account);

        return transaction;
    }
}
