using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BudgetApp.Domain.Services;

public class IncomeService(IIncomeRepository incomeRepository, ITransactionService transactionService) : IIncomeService
{
    public async Task<Income> CreateAsync(decimal amount, DateTime effectiveFrom, int accountId)
    {
        Income income = new Income(amount, effectiveFrom);
        income.AssignToAccount(accountId);

        return await incomeRepository.AddAsync(income);
    }

    public async Task DeleteAsync(int incomeId)
    {
        var income = await incomeRepository.GetByIdAsync(incomeId);

        if (income is null)
        {
            throw new InvalidOperationException($"Income with ID {incomeId} does not exist.");
        }

        await incomeRepository.DeleteAsync(income);
    }

    public Task<IReadOnlyList<Income>> GetByAccountIdAsync(int accountId)
        => incomeRepository.GetByAccountIdAsync(accountId);

    public async Task EnsureMonthlyTransactionAsync(int accountId, DateTime month)
    {
        if (accountId <= 0) return;

        var today = month.Date;
        var incomes = (await incomeRepository.GetByAccountIdAsync(accountId))
            .Where(i => i.EffectiveFrom.Date <= today)
            .OrderByDescending(i => i.EffectiveFrom)
            .ThenByDescending(i => i.Id)
            .ToList();

        if (incomes.Count == 0) return;

        var transactions = await transactionService.GetByAccountIdAsync(accountId);
        var firstMonth = new DateTime(incomes.Min(i => i.EffectiveFrom).Year, incomes.Min(i => i.EffectiveFrom).Month, 1);
        var currentMonth = new DateTime(today.Year, today.Month, 1);

        // Werk alle maanden bij tot en met vandaag. Zo worden gemiste maanden
        // ingehaald wanneer de gebruiker de app een tijdje niet heeft geopend.
        for (var monthStart = firstMonth; monthStart <= currentMonth; monthStart = monthStart.AddMonths(1))
        {
            var income = incomes
                .Where(i => i.EffectiveFrom.Date <= monthStart.AddMonths(1).AddDays(-1))
                .OrderByDescending(i => i.EffectiveFrom)
                .ThenByDescending(i => i.Id)
                .FirstOrDefault();

            if (income is null) continue;

            var paymentDay = Math.Min(income.EffectiveFrom.Day, DateTime.DaysInMonth(monthStart.Year, monthStart.Month));
            var paymentDate = new DateTime(monthStart.Year, monthStart.Month, paymentDay);
            if (paymentDate < income.EffectiveFrom.Date || paymentDate > today) continue;

            var marker = $"[AUTO-INCOME:{income.Id}:{monthStart:yyyy-MM}]";
            if (transactions.Any(t => t.Description == marker)) continue;

            await transactionService.CreateAsync(
                income.Amount,
                paymentDate,
                marker,
                TransactionType.Income,
                CategoryType.Salary,
                accountId);

            transactions = await transactionService.GetByAccountIdAsync(accountId);
        }
    }

    public async Task AssignToAccountAsync(int incomeId, int accountId)
    {
        var income = await incomeRepository.GetByIdAsync(incomeId)
            ?? throw new ArgumentException("Income not found.");
        income.AssignToAccount(accountId);
        await incomeRepository.UpdateAsync(income);
    }

    public async Task<IReadOnlyList<Income>> GetAllAsync()
    {
        return await incomeRepository.GetAllAsync();
    }

    public async Task<Income?> GetByIdAsync(int id)
    {
        var income = await incomeRepository.GetByIdAsync(id);

        if(income is null)
        {
            throw new InvalidOperationException($"Income with ID {id} does not exist.");
        }

        return income;
    }

    public async Task<Income?> GetEffectiveIncomeAsync(DateTime date)
    {
        var income = await incomeRepository.GetEffectiveIncomeAsync(date);

        if(income is null)
        {
            throw new InvalidOperationException($"No effective income found for date {date}.");
        }

        return income;
    }

    public async Task<Income> UpdateAmountAsync(int incomeId, decimal newAmount)
    {
        var income = await incomeRepository.GetByIdAsync(incomeId);

        if (income is null)
        {
            throw new InvalidOperationException($"Income with ID {incomeId} does not exist.");
        }

        income.UpdateAmount(newAmount);
        return await incomeRepository.UpdateAsync(income);
    }

    public async Task<Income> UpdateEffectiveFromAsync(int incomeId, DateTime effectiveFrom)
    {
        var income = await incomeRepository.GetByIdAsync(incomeId);

        if (income is null)
        {
            throw new InvalidOperationException($"Income with ID {incomeId} does not exist.");
        }

        income.UpdateEffectiveFrom(effectiveFrom);
        return await incomeRepository.UpdateAsync(income);
    }
}
