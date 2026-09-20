using BudgetApp.Domain.Enums;

namespace BudgetApp.Domain.Models;

public sealed record ExpenseCategorySummary(CategoryType Category, decimal Amount);
