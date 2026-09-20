using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Domain.Interfaces.Services;

public interface IAccountService
{
    Task<Account> CreateAsync(
    string name,
    AccountType type,
    decimal balance);

    Task<Account?> GetByIdAsync(int id);

    Task<IReadOnlyList<Account>> GetAllAsync();

    Task<Account> RenameAsync(int accountId, string newName);

    Task DeleteAsync(int accountId);

}
