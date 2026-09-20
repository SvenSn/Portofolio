using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Services;
using BudgetApp.Infrastructure.Data;
using BudgetApp.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Tests;

public sealed class AccountIsolationTests
{
    private sealed class Factory(DbContextOptions<BudgetDbContext> options) : IDbContextFactory<BudgetDbContext>
    {
        public BudgetDbContext CreateDbContext() => new(options);
    }

    [Fact]
    public async Task IncomeBudgetsAndMonthlySummaryAreAccountSpecific()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var factory = new Factory(new DbContextOptionsBuilder<BudgetDbContext>().UseSqlite(connection).Options);
        using (var db = factory.CreateDbContext()) DatabaseInitializer.Initialize(db);
        var accounts = new AccountRepository(factory);
        var first = await accounts.AddAsync(new Account("A", AccountType.Checking, 0));
        var second = await accounts.AddAsync(new Account("B", AccountType.Checking, 0));
        var budgets = new BudgetService(new BudgetRepository(factory));
        var transactions = new TransactionService(new TransactionRepository(factory), accounts);
        var income = new IncomeService(new IncomeRepository(factory), transactions);
        var finance = new MonthlyFinanceService(transactions);
        var date = new DateTime(2026, 9, 12);
        await income.CreateAsync(1200m, date, first.Id);
        await income.CreateAsync(2500m, date, second.Id);
        await budgets.CreateAsync(CategoryType.Housing, 400m, 9, 2026, first.Id);
        await budgets.CreateAsync(CategoryType.Food, 800m, 9, 2026, second.Id);
        await transactions.CreateAsync(100m, date, "Rent", TransactionType.Expense, CategoryType.Housing, first.Id);
        await transactions.CreateAsync(300m, date, "Food", TransactionType.Expense, CategoryType.Food, second.Id);
        var summary = await finance.GetSummaryAsync(2026, 9, first.Id);
        Assert.Equal(100m, summary.Expenses);
        Assert.Equal(CategoryType.Housing, Assert.Single(summary.ExpenseCategories).Category);
        Assert.Single(await income.GetByAccountIdAsync(first.Id));
        Assert.Single(await budgets.GetByAccountIdAsync(first.Id));
    }

    [Fact]
    public async Task LegacyRecordsRemainUnassignedAfterSchemaUpgrade()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var factory = new Factory(new DbContextOptionsBuilder<BudgetDbContext>().UseSqlite(connection).Options);
        using (var db = factory.CreateDbContext())
        {
            await db.Database.EnsureCreatedAsync();
            await db.Database.ExecuteSqlRawAsync("""DROP TABLE "Incomes"; DROP TABLE "Budgets";""");
            await db.Database.ExecuteSqlRawAsync("""
                CREATE TABLE "Incomes" ("Id" INTEGER PRIMARY KEY AUTOINCREMENT, "Amount" INTEGER NOT NULL, "EffectiveFrom" TEXT NOT NULL);
                CREATE TABLE "Budgets" ("Id" INTEGER PRIMARY KEY AUTOINCREMENT, "Category" INTEGER NOT NULL, "Amount" INTEGER NOT NULL, "Month" INTEGER NOT NULL, "Year" INTEGER NOT NULL);
                INSERT INTO "Incomes" ("Amount","EffectiveFrom") VALUES (120000,'2026-09-12 00:00:00');
                INSERT INTO "Budgets" ("Category","Amount","Month","Year") VALUES (0,40000,9,2026);
                """);
            DatabaseInitializer.Initialize(db);
            DatabaseInitializer.Initialize(db);
        }
        var budgets = new BudgetService(new BudgetRepository(factory));
        var accounts = new AccountRepository(factory);
        var transactions = new TransactionService(new TransactionRepository(factory), accounts);
        var income = new IncomeService(new IncomeRepository(factory), transactions);
        Assert.Null(Assert.Single(await income.GetAllAsync()).AccountId);
        Assert.Null(Assert.Single(await budgets.GetAllAsync()).AccountId);
    }
}
