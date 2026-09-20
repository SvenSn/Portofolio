using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Domain.Interfaces.Services;

namespace BudgetApp.Domain.Services;

public class AccountService(IAccountRepository accountRepository) : IAccountService
{
    public async Task<Account> CreateAsync(string name, AccountType type, decimal balance)
    {
        Account account = new Account(name, type, balance);

        return await accountRepository.AddAsync(account);
    }

    public async Task DeleteAsync(int accountId)
    {
        var account = await accountRepository.GetByIdAsync(accountId);

        if (account == null)
        {
            throw new InvalidOperationException("Account was not found.");
        }

        await accountRepository.DeleteAsync(account);
    }

    public async Task<IReadOnlyList<Account>> GetAllAsync()
    {
        return await accountRepository.GetAllAsync();
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        var account = await accountRepository.GetByIdAsync(id);

        if(account is null)
        {
            throw new InvalidOperationException("Account was not found.");
        }

        return account;
    }
    public async Task<Account> RenameAsync(int accountId, string newName)
    {
        var account = await accountRepository.GetByIdAsync(accountId);

        if (account is null)
        {
            throw new InvalidOperationException("Account was not found.");
        }

        account.UpdateName(newName);

        await accountRepository.UpdateAsync(account);

        return account;
    }
}
