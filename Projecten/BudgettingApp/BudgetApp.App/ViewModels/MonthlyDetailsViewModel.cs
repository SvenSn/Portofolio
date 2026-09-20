using CommunityToolkit.Mvvm.ComponentModel;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Entities;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;
public partial class MonthlyDetailsViewModel(IMonthlyFinanceService finance, ITransactionService transactions, IIncomeService incomes, Services.ActiveAccountState active) : ScreenViewModel, IQueryAttributable
{
    private int _year = DateTime.Today.Year;
    private int _month = DateTime.Today.Month;
    [ObservableProperty] public partial string Heading { get; set; } = L.T("Maandoverzicht");
    [ObservableProperty] public partial decimal Income { get; set; }
    [ObservableProperty] public partial decimal Expenses { get; set; }
    [ObservableProperty] public partial decimal Remaining { get; set; }
    [ObservableProperty] public partial IReadOnlyList<Transaction> Items { get; set; } = [];
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("year", out var y) && int.TryParse(y.ToString(), out var year) && year >= 2000 && year <= 9999) _year = year;
        if (query.TryGetValue("month", out var m) && int.TryParse(m.ToString(), out var month) && month >= 1 && month <= 12) _month = month;
    }
    public override async Task RefreshAsync()
    {
        var accountId = active.Id;
        if (_year == DateTime.Today.Year && _month == DateTime.Today.Month)
            await incomes.EnsureMonthlyTransactionAsync(accountId, DateTime.Today);
        var summary = await finance.GetSummaryAsync(_year, _month, accountId);
        Income = summary.Income;
        Expenses = summary.Expenses; Remaining = Income - Expenses;
        Heading = new DateTime(_year, _month, 1).ToString("Y", System.Globalization.CultureInfo.CurrentCulture);
        Items = (await transactions.GetByAccountIdAsync(accountId)).Where(t => t.Date.Year == _year && t.Date.Month == _month).OrderByDescending(t => t.Date).ToList();
        Message = Items.Count == 0 ? L.T("Geen transacties in deze maand.") : "";
    }
}
