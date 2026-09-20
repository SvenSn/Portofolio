using BudgetApp.Domain.Entities;

namespace BudgetApp.Domain.Interfaces.Repositories;

public interface ISavingsGoalRepository
{
    Task<SavingsGoal?> GetByIdAsync(int id);

    Task<IReadOnlyList<SavingsGoal>> GetAllAsync();
    Task<IReadOnlyList<SavingsGoal>> GetByAccountIdAsync(int accountId);

    Task<SavingsGoal> AddAsync(SavingsGoal savingsGoal);

    Task<SavingsGoal> UpdateAsync(SavingsGoal savingsGoal);

    Task DeleteAsync(SavingsGoal savingsGoal);
}
