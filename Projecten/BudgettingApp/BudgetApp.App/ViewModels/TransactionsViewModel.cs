using CommunityToolkit.Mvvm.ComponentModel;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Entities;
using CommunityToolkit.Mvvm.Input;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;
public partial class TransactionsViewModel(ITransactionService service, Services.ActiveAccountState active) : ScreenViewModel
{
    [ObservableProperty] public partial IReadOnlyList<Transaction> Items { get; set; } = [];
    [ObservableProperty] public partial Transaction? Selected { get; set; }
    public override async Task RefreshAsync()
    {
        Items = (await service.GetByAccountIdAsync(active.Id)).OrderByDescending(t => t.Date).ToList();
        Selected = null;
        Message = active.Current is null ? L.Get("AccountsEmpty") :
            Items.Count == 0 ? L.Get("AccountTransactionsEmpty") : "";
    }
    [RelayCommand] private async Task AddAsync()
    {
        if (active.Current is null) { Message = L.Get("SelectAccountFirst"); return; }
        await Shell.Current.GoToAsync(nameof(Views.AddTransactionPage));
    }
    [RelayCommand] private async Task EditAsync()
    {
        if (Selected is null) { Message = L.T("Selecteer eerst een transactie."); return; }
        await Shell.Current.GoToAsync($"{nameof(Views.AddTransactionPage)}?id={Selected.Id}");
    }
    [RelayCommand] private Task DeleteAsync() => RunAsync(async () =>
    {
        if (Selected is null) { Message = L.T("Selecteer eerst een transactie."); return; }
        if (!await Shell.Current.DisplayAlertAsync(L.T("Transactie verwijderen"), L.T("Deze transactie verwijderen en het saldo-effect terugdraaien?"), L.T("Verwijderen"), L.T("Annuleren"))) return;
        await service.DeleteAsync(Selected.Id);
        await RefreshAsync();
    });
}
