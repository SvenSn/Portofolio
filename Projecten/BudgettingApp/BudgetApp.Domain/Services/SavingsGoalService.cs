using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Domain.Interfaces.Services;

namespace BudgetApp.Domain.Services;

public class SavingsGoalService(ISavingsGoalRepository savingsGoalRepository) : ISavingsGoalService
{
    public async Task<SavingsGoal> UpdateAsync(int id, string name, decimal targetAmount, DateTime targetDate)
    {
        var goal = await savingsGoalRepository.GetByIdAsync(id)
            ?? throw new ArgumentException("Spaardoel niet gevonden.");
        goal.UpdateName(name);
        goal.UpdateTargetAmount(targetAmount);
        goal.UpdateTargetDate(targetDate);
        return await savingsGoalRepository.UpdateAsync(goal);
    }
    public async Task<SavingsGoal> AddAmountAsync(int savingsGoalId, decimal amount)
    {
        var savingsGoal = await savingsGoalRepository.GetByIdAsync(savingsGoalId);
        if (savingsGoal == null) throw new ArgumentException("Savings goal not found");

        savingsGoal.AddAmount(amount);
        return await savingsGoalRepository.UpdateAsync(savingsGoal);
    }

    public async Task<SavingsGoal> CreateAsync(string name, decimal targetAmount, decimal currentAmount, DateTime targetDate, int accountId)
    {
        SavingsGoal newSavingsGoal = new SavingsGoal(name, targetAmount, currentAmount, targetDate);
        newSavingsGoal.AssignToAccount(accountId);

        var savedSavingsGoal = await savingsGoalRepository.AddAsync(newSavingsGoal);

        return savedSavingsGoal;
    }

    public async Task DeleteAsync(int savingsGoalId)
    {
        var savingsGoal = await savingsGoalRepository.GetByIdAsync(savingsGoalId);
        if (savingsGoal == null) throw new ArgumentException("Savings goal not found");

        await savingsGoalRepository.DeleteAsync(savingsGoal);
    }

    public async Task<IReadOnlyList<SavingsGoal>> GetAllAsync()
    {
        return await savingsGoalRepository.GetAllAsync();
    }

    public Task<IReadOnlyList<SavingsGoal>> GetByAccountIdAsync(int accountId) =>
        savingsGoalRepository.GetByAccountIdAsync(accountId);

    public async Task<SavingsGoal> AssignToAccountAsync(int goalId, int accountId)
    {
        var goal = await savingsGoalRepository.GetByIdAsync(goalId)
            ?? throw new ArgumentException("Spaardoel niet gevonden.");
        if (goal.AccountId is not null)
            throw new InvalidOperationException("This goal already belongs to an account.");
        goal.AssignToAccount(accountId);
        return await savingsGoalRepository.UpdateAsync(goal);
    }

    public async Task<SavingsGoal?> GetByIdAsync(int id)
    {
        var savingsGoal = await savingsGoalRepository.GetByIdAsync(id);

        if(savingsGoal == null)
        {
            throw new InvalidOperationException("Savings goal not found");
        }
        return savingsGoal;
    }

    public async Task<SavingsGoal> UpdateNameAsync(int savingsGoalId, string newName)
    {
        var savingsGoal = await savingsGoalRepository.GetByIdAsync(savingsGoalId);

        if (savingsGoal == null)
        {
            throw new InvalidOperationException("Savings goal not found");
        }

        savingsGoal.UpdateName(newName);

        return await savingsGoalRepository.UpdateAsync(savingsGoal);
    }

    public async Task<SavingsGoal> UpdateTargetAmountAsync(int savingsGoalId, decimal newTargetAmount)
    {
        var savingsGoal = await savingsGoalRepository.GetByIdAsync(savingsGoalId);

        if (savingsGoal == null)
        {
            throw new InvalidOperationException("Savings goal not found");
        }

        savingsGoal.UpdateTargetAmount(newTargetAmount);

        return await savingsGoalRepository.UpdateAsync(savingsGoal);
    }

    public async Task<SavingsGoal> UpdateTargetDateAsync(int savingsGoalId, DateTime newTargetDate)
    {
        var savingsGoal = await savingsGoalRepository.GetByIdAsync(savingsGoalId);

        if (savingsGoal == null)
        {
            throw new InvalidOperationException("Savings goal not found");
        }

        savingsGoal.UpdateTargetDate(newTargetDate);

        return await savingsGoalRepository.UpdateAsync(savingsGoal);
    }
}
