using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;
using BudgetApp.Infrastructure.Data;
using BudgetApp.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Tests;

public sealed class RepositoryTests
{
    private sealed class Fixture : IAsyncDisposable
    {
        public SqliteConnection Connection { get; } = new("Data Source=:memory:");
        public IDbContextFactory<BudgetDbContext> Factory { get; }
        public Fixture()
        {
            Connection.Open();
            Factory = new Factory(new DbContextOptionsBuilder<BudgetDbContext>().UseSqlite(Connection).Options);
            using var context = Factory.CreateDbContext();
            DatabaseInitializer.Initialize(context);
        }
        public ValueTask DisposeAsync() => Connection.DisposeAsync();
    }

    private sealed class Factory(DbContextOptions<BudgetDbContext> options) : IDbContextFactory<BudgetDbContext>
    {
        public BudgetDbContext CreateDbContext() => new(options);
    }

    [Fact]
    public async Task AccountRepositoryPersistsAndReadsAccounts()
    {
        await using var fixture = new Fixture();
        var repository = new AccountRepository(fixture.Factory);
        var saved = await repository.AddAsync(new Account("Daily", AccountType.Checking, 250m));
        Assert.Equal(saved.Id, (await repository.GetByIdAsync(saved.Id))!.Id);
        Assert.Single(await repository.GetAllAsync());
    }

    [Fact]
    public async Task TransactionRepositoryFiltersByAccountAndPreservesCents()
    {
        await using var fixture = new Fixture();
        var accounts = new AccountRepository(fixture.Factory);
        var transactions = new TransactionRepository(fixture.Factory);
        var first = await accounts.AddAsync(new Account("First", AccountType.Checking, 100m));
        var second = await accounts.AddAsync(new Account("Second", AccountType.Savings, 100m));
        var kept = await transactions.AddAsync(new Transaction(12.34m, DateTime.Today, "Food", TransactionType.Expense, CategoryType.Food, first.Id));
        await transactions.AddAsync(new Transaction(99.99m, DateTime.Today, "Other", TransactionType.Expense, CategoryType.Other, second.Id));
        var result = await transactions.GetByAccountIdAsync(first.Id);
        Assert.Equal(kept.Id, Assert.Single(result).Id);
        Assert.Equal(12.34m, result[0].Amount);
    }

    [Fact]
    public async Task DeletingAccountKeepsAnotherAccountsTransactions()
    {
        await using var fixture = new Fixture();
        var accounts = new AccountRepository(fixture.Factory);
        var transactions = new TransactionRepository(fixture.Factory);
        var first = await accounts.AddAsync(new Account("First", AccountType.Checking, 100m));
        var second = await accounts.AddAsync(new Account("Second", AccountType.Checking, 100m));
        await transactions.AddAsync(new Transaction(10m, DateTime.Today, "First", TransactionType.Expense, CategoryType.Other, first.Id));
        var kept = await transactions.AddAsync(new Transaction(20m, DateTime.Today, "Second", TransactionType.Expense, CategoryType.Other, second.Id));
        await accounts.DeleteAsync(first);
        Assert.Null(await accounts.GetByIdAsync(first.Id));
        Assert.Equal(kept.Id, Assert.Single(await transactions.GetAllAsync()).Id);
    }
}
