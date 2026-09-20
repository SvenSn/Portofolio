using CommunityToolkit.Mvvm.ComponentModel;
using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Entities;
using CommunityToolkit.Mvvm.Input;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;
public partial class SavingsViewModel(IAccountService accounts, ISavingsGoalService goals, Services.ActiveAccountState active) : ScreenViewModel
{
    [ObservableProperty] public partial IReadOnlyList<Account> Items { get; set; } = [];
    [ObservableProperty] public partial decimal Total { get; set; }
    [ObservableProperty] public partial string GoalSummary { get; set; } = "";
    public override async Task RefreshAsync()
    {
        var accountId = active.Id;
        Items = (await accounts.GetAllAsync()).Where(a => a.Id == accountId).ToList();
        Total = Items.Sum(a => a.Balance);
        var allGoals = await goals.GetByAccountIdAsync(accountId);
        GoalSummary = L.Format("{0} actieve doelen · {1} behaald", allGoals.Count(g => !g.IsCompleted), allGoals.Count(g => g.IsCompleted));
        Message = Items.Count == 0 ? L.Get("AccountsEmpty") : L.Get("SelectedAccountBalance");
    }
    [RelayCommand] private Task GoalsAsync() => Shell.Current.GoToAsync(nameof(Views.SavingsGoalPage));
    [RelayCommand] private Task AddAccountAsync() => Shell.Current.GoToAsync(nameof(Views.CreateNewAccountPage));
}
