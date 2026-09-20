using BudgetApp.App.Services;
using BudgetApp.App.ViewModels;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Services;

namespace BudgetApp.Tests;

public sealed class ViewModelTests
{
    [Fact]
    public async Task CreateAccountViewModelRejectsEmptyName()
    {
        var service = new FakeAccountService();
        var viewModel = new CreateNewAccountViewModel(service);
        await viewModel.CreateAccountCommand.ExecuteAsync(null);
        Assert.Equal("Vul een rekeningnaam in.", viewModel.ErrorMessage);
        Assert.Equal(0, service.CreateCalls);
    }

    [Fact]
    public async Task CreateAccountViewModelTrimsNameAndRaisesEvent()
    {
        var service = new FakeAccountService();
        var viewModel = new CreateNewAccountViewModel(service)
        {
            Name = "  Holiday  ",
            OpeningBalance = 1234.56m.ToString(System.Globalization.CultureInfo.CurrentCulture),
            SelectedAccountType = AccountType.Savings
        };
        var raised = false;
        viewModel.AccountCreated += (_, _) => raised = true;
        await viewModel.CreateAccountCommand.ExecuteAsync(null);
        Assert.Equal("Holiday", service.Name);
        Assert.Equal(1234.56m, service.Balance);
        Assert.True(raised);
    }

    [Fact]
    public async Task IncomeViewModelLoadsCurrentIncome()
    {
        var service = new FakeIncomeService();
        service.Items.Add(new Income(1200m, DateTime.Today));
        var viewModel = new IncomeViewModel(service, new ActiveAccountState());
        await viewModel.LoadCommand.ExecuteAsync(null);
        Assert.Single(viewModel.Incomes);
        Assert.Equal($"€ {1200m:N2}", viewModel.CurrentIncome);
        Assert.False(viewModel.IsEmpty);
    }

    private sealed class FakeAccountService : IAccountService
    {
        public int CreateCalls { get; private set; }
        public string? Name { get; private set; }
        public decimal Balance { get; private set; }
        public Task<Account> CreateAsync(string name, AccountType type, decimal balance) { CreateCalls++; Name = name; Balance = balance; return Task.FromResult(new Account(name, type, balance)); }
        public Task<Account?> GetByIdAsync(int id) => Task.FromResult<Account?>(null);
        public Task<IReadOnlyList<Account>> GetAllAsync() => Task.FromResult<IReadOnlyList<Account>>([]);
        public Task<Account> RenameAsync(int accountId, string newName) => throw new NotSupportedException();
        public Task DeleteAsync(int accountId) => throw new NotSupportedException();
    }

    private sealed class FakeIncomeService : IIncomeService
    {
        public List<Income> Items { get; } = [];
        public Task<Income> CreateAsync(decimal amount, DateTime effectiveFrom, int accountId) => throw new NotSupportedException();
        public Task<IReadOnlyList<Income>> GetByAccountIdAsync(int accountId) => Task.FromResult<IReadOnlyList<Income>>(Items);
        public Task EnsureMonthlyTransactionAsync(int accountId, DateTime month) => Task.CompletedTask;
        public Task AssignToAccountAsync(int incomeId, int accountId) => throw new NotSupportedException();
        public Task<Income?> GetByIdAsync(int id) => Task.FromResult<Income?>(null);
        public Task<IReadOnlyList<Income>> GetAllAsync() => Task.FromResult<IReadOnlyList<Income>>(Items);
        public Task<Income?> GetEffectiveIncomeAsync(DateTime date) => Task.FromResult<Income?>(null);
        public Task<Income> UpdateAmountAsync(int incomeId, decimal newAmount) => throw new NotSupportedException();
        public Task<Income> UpdateEffectiveFromAsync(int incomeId, DateTime effectiveFrom) => throw new NotSupportedException();
        public Task DeleteAsync(int incomeId) => throw new NotSupportedException();
    }
}
