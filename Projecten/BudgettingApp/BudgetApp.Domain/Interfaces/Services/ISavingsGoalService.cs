using BudgetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp.Domain.Interfaces.Services;

public interface ISavingsGoalService
{
    Task<SavingsGoal> CreateAsync(
    string name,
    decimal targetAmount,
    decimal currentAmount,
    DateTime targetDate,
    int accountId);

    Task<SavingsGoal?> GetByIdAsync(int id);

    Task<IReadOnlyList<SavingsGoal>> GetAllAsync();
    Task<IReadOnlyList<SavingsGoal>> GetByAccountIdAsync(int accountId);
    Task<SavingsGoal> AssignToAccountAsync(int goalId, int accountId);

    Task<SavingsGoal> UpdateNameAsync(
        int savingsGoalId,
        string newName);

    Task<SavingsGoal> UpdateTargetAmountAsync(
        int savingsGoalId,
        decimal newTargetAmount);

    Task<SavingsGoal> UpdateTargetDateAsync(
        int savingsGoalId,
        DateTime newTargetDate);

    Task<SavingsGoal> AddAmountAsync(
        int savingsGoalId,
        decimal amount);

    Task DeleteAsync(int savingsGoalId);
    Task<SavingsGoal> UpdateAsync(int id, string name, decimal targetAmount, DateTime targetDate);
}
