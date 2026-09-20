using CommunityToolkit.Mvvm.ComponentModel;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Entities;
using CommunityToolkit.Mvvm.Input;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;
public partial class SavingsGoalViewModel(ISavingsGoalService service, Services.ActiveAccountState active) : ScreenViewModel
{
    private int _loadedAccountId;
    [ObservableProperty] public partial IReadOnlyList<SavingsGoal> UnassignedGoals { get; set; } = [];
    [ObservableProperty] public partial SavingsGoal? SelectedUnassignedGoal { get; set; }
    [ObservableProperty] public partial bool HasUnassignedGoals { get; set; }
    [RelayCommand] private Task AssignAsync() => RunAsync(async () =>
    {
        if (active.Current is null || SelectedUnassignedGoal is null)
        {
            Message = L.Get("SelectGoalAndAccount");
            return;
        }
        await service.AssignToAccountAsync(SelectedUnassignedGoal.Id, active.RequireId());
        await RefreshAsync();
        Message = L.Get("GoalAssigned");
    });
    private int? _editingId;
    [ObservableProperty] public partial bool IsCreating { get; set; } = true;
    [ObservableProperty] public partial string SaveLabel { get; set; } = L.T("Spaardoel aanmaken");
    [RelayCommand] private void Edit()
    {
        if (Selected is null) { Message = L.T("Selecteer eerst een spaardoel."); return; }
        _editingId = Selected.Id;
        Name = Selected.Name;
        Target = Selected.TargetAmount.ToString(System.Globalization.CultureInfo.CurrentCulture);
        TargetDate = Selected.TargetDate;
        IsCreating = false;
        SaveLabel = L.T("Wijzigingen opslaan");
        Message = L.Format("Je bewerkt: {0}", Selected.Name);
    }
    [RelayCommand] private void Cancel()
    {
        _editingId = null;
        IsCreating = true;
        SaveLabel = L.T("Spaardoel aanmaken");
        Name = ""; Target = ""; Initial = "0";
        TargetDate = DateTime.Today.AddMonths(6);
    }
    [ObservableProperty] public partial IReadOnlyList<SavingsGoal> Items { get; set; } = [];
    [ObservableProperty] public partial SavingsGoal? Selected { get; set; }
    [ObservableProperty] public partial string Name { get; set; } = "";
    [ObservableProperty] public partial string Target { get; set; } = "";
    [ObservableProperty] public partial string Initial { get; set; } = "0";
    [ObservableProperty] public partial string Contribution { get; set; } = "";
    [ObservableProperty] public partial DateTime? TargetDate { get; set; } = DateTime.Today.AddMonths(6);
    public override async Task RefreshAsync()
    {
        var accountId = active.Id;
        if (_loadedAccountId != accountId)
        {
            Cancel();
            Contribution = "";
            _loadedAccountId = accountId;
        }
        Items = (await service.GetByAccountIdAsync(accountId)).OrderBy(goal => goal.TargetDate).ToList();
        UnassignedGoals = (await service.GetAllAsync()).Where(goal => goal.AccountId is null).ToList();
        SelectedUnassignedGoal = null;
        HasUnassignedGoals = UnassignedGoals.Count > 0;
        Selected = null;
        Message = active.Current is null ? L.Get("AccountsEmpty") : Items.Count == 0 ? L.Get("NoAccountGoals") : "";
    }
    [RelayCommand] private Task SaveAsync() => RunAsync(async () =>
    {
        if (string.IsNullOrWhiteSpace(Name) || TargetDate is null) throw new ArgumentException(L.T("Vul een naam en doeldatum in."));
        var accountId = active.RequireId();
        if (Name.Trim().Length > 100) throw new ArgumentException(L.T("Gebruik maximaal 100 tekens voor de naam."));
        if (_editingId is { } id)
            await service.UpdateAsync(id, Name.Trim(), Money(Target), TargetDate.Value.Date);
        else
            await service.CreateAsync(Name.Trim(), Money(Target), Money(Initial, true), TargetDate.Value.Date, accountId);
        Cancel();
        await RefreshAsync(); Message = L.T("Spaardoel opgeslagen.");
    });
    [RelayCommand] private Task ContributeAsync() => RunAsync(async () =>
    {
        if (Selected is null) { Message = L.T("Selecteer eerst een spaardoel."); return; }
        await service.AddAmountAsync(Selected.Id, Money(Contribution));
        Contribution = ""; await RefreshAsync(); Message = L.T("Voortgang bijgewerkt.");
    });
    [RelayCommand] private Task DeleteAsync() => RunAsync(async () =>
    {
        if (Selected is null) { Message = L.T("Selecteer eerst een spaardoel."); return; }
        if (!await Shell.Current.DisplayAlertAsync(L.T("Spaardoel verwijderen"), L.T("Dit spaardoel verwijderen?"), L.T("Verwijderen"), L.T("Annuleren"))) return;
        await service.DeleteAsync(Selected.Id);
        Cancel();
        await RefreshAsync();
        Message = L.T("Spaardoel verwijderd.");
    });
}
