using BudgetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Domain.Interfaces.Repositories;

public interface ITransactionRepository
{
    Task<Transaction?> GetByIdAsync(int id);
    Task<IReadOnlyList<Transaction>> GetAllAsync();
    Task<IReadOnlyList<Transaction>> GetByAccountIdAsync(int accountId);
    Task<Transaction> AddAsync(Transaction transaction);
    Task<Transaction> UpdateAsync(Transaction transaction);
    Task UpdateWithAccountAsync(Transaction transaction, Account account);
    Task DeleteAsync(Transaction transaction);
}
