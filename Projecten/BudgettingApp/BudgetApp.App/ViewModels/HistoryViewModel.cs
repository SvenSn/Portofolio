using CommunityToolkit.Mvvm.ComponentModel;
using BudgetApp.Domain.Interfaces.Services;
using CommunityToolkit.Mvvm.Input;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;
public record HistoryRow(int Year, int Month, string Label);
public partial class HistoryViewModel(ITransactionService transactions, IIncomeService incomes, Services.ActiveAccountState active) : ScreenViewModel
{
    [ObservableProperty] public partial IReadOnlyList<HistoryRow> Items { get; set; } = [];
    [ObservableProperty] public partial HistoryRow? Selected { get; set; }
    public override async Task RefreshAsync()
    {
        var accountId = active.Id;
        Selected = null;
        var dates = (await transactions.GetByAccountIdAsync(accountId)).Select(t => t.Date)
            .Concat((await incomes.GetByAccountIdAsync(accountId)).Select(i => i.EffectiveFrom)).Append(DateTime.Today);
        Items = dates.Select(d => new DateTime(d.Year, d.Month, 1)).Distinct().OrderByDescending(d => d)
            .Select(d => new HistoryRow(d.Year, d.Month, d.ToString("Y", System.Globalization.CultureInfo.CurrentCulture))).ToList();
    }
    [RelayCommand] private async Task OpenAsync()
    {
        if (Selected is null) { Message = L.T("Selecteer een maand."); return; }
        await Shell.Current.GoToAsync($"{nameof(Views.MonthlyDetailsPage)}?year={Selected.Year}&month={Selected.Month}");
    }
}
