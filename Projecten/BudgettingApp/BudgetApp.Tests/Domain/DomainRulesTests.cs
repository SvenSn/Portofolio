using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;

namespace BudgetApp.Tests;

public sealed class DomainRulesTests
{
    [Fact]
    public void AccountAppliesIncomeAndExpenseToBalance()
    {
        var account = new Account("Daily", AccountType.Checking, 100m);
        account.ApplyTransaction(25m, TransactionType.Income);
        account.ApplyTransaction(40m, TransactionType.Expense);
        Assert.Equal(85m, account.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void AccountRejectsNonPositiveTransaction(decimal amount)
    {
        var account = new Account("Daily", AccountType.Checking, 100m);
        Assert.Throws<ArgumentOutOfRangeException>(() => account.ApplyTransaction(amount, TransactionType.Expense));
    }

    [Fact]
    public void SavingsGoalBecomesCompletedAtTarget()
    {
        var goal = new SavingsGoal("Holiday", 1000m, 750m, DateTime.Today);
        Assert.False(goal.IsCompleted);
        goal.AddAmount(250m);
        Assert.True(goal.IsCompleted);
    }

    [Fact]
    public void AccountOwnershipCanOnlyBeAssignedOnce()
    {
        var income = new Income(1200m, DateTime.Today);
        income.AssignToAccount(7);
        Assert.Equal(7, income.AccountId);
        Assert.Throws<InvalidOperationException>(() => income.AssignToAccount(8));
    }
}
