using BudgetApp.App.Localization;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BudgetApp.App.ViewModels;

public partial class AccountsViewModel(IAccountService accounts, Services.ActiveAccountState active) : ScreenViewModel
{
    [ObservableProperty] public partial IReadOnlyList<Account> Items { get; set; } = [];
    [ObservableProperty] public partial Account? Selected { get; set; }

    public override async Task RefreshAsync()
    {
        Items = (await accounts.GetAllAsync()).OrderBy(account => account.Name).ToList();
        Selected = null;
        Message = Items.Count == 0 ? L.Get("AccountsEmpty") : "";
    }

    [RelayCommand]
    private Task AddAsync() => Shell.Current.GoToAsync(nameof(Views.CreateNewAccountPage));

    [RelayCommand]
    private void Activate()
    {
        if (Selected is null) { Message = L.Get("SelectAccountFirst"); return; }
        active.Select(Selected);
        Message = SystemValueFormatter.Format(L.Get("AccountActivated"), Selected.Name);
    }

    [RelayCommand]
    private Task DeleteAsync() => RunAsync(async () =>
    {
        if (Selected is not { } account)
        {
            Message = L.Get("SelectAccountFirst");
            return;
        }
        if (!await Shell.Current.DisplayAlertAsync(L.Get("DeleteAccount"),
            SystemValueFormatter.Format(L.Get("DeleteAccountConfirm"), account.Name),
            L.T("Verwijderen"), L.T("Annuleren"))) return;

        await accounts.DeleteAsync(account.Id);
        await active.RefreshAsync();
        await RefreshAsync();
        Message = Items.Count == 0 ? L.Get("AccountsEmpty") : L.Get("AccountDeleted");
    });
}
