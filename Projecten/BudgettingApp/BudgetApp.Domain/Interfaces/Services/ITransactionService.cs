using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;

namespace BudgetApp.Domain.Interfaces.Services;

public interface ITransactionService
{
    Task<Transaction> CreateAsync(
    decimal amount,
    DateTime date,
    string description,
    TransactionType type,
    CategoryType category,
    int accountId);

    Task<Transaction?> GetByIdAsync(int id);

    Task<IReadOnlyList<Transaction>> GetAllAsync();

    Task<IReadOnlyList<Transaction>> GetByMonthAsync(
        int year,
        int month);

    Task<IReadOnlyList<Transaction>> GetByAccountIdAsync(
        int accountId);

    Task<Transaction> UpdateAsync(
        int transactionId,
        decimal amount,
        DateTime date,
        string description,
        TransactionType type,
        CategoryType category);

    Task DeleteAsync(int transactionId);
}
