using BudgetApp.Domain.Entities;

namespace BudgetApp.Domain.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(int accountId);
    Task<IReadOnlyList<Account>> GetAllAsync();
    Task<Account> AddAsync(Account account);
    Task<Account> UpdateAsync(Account account);
    Task DeleteAsync(Account account);
}
