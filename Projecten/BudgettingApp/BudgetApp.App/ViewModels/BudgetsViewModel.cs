using CommunityToolkit.Mvvm.ComponentModel;
using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Entities;
using CommunityToolkit.Mvvm.Input;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;
public partial class BudgetsViewModel(IBudgetService service, Services.ActiveAccountState active) : ScreenViewModel
{
    [ObservableProperty] public partial IReadOnlyList<UnassignedRecord> Unassigned { get; set; } = [];
    [ObservableProperty] public partial UnassignedRecord? SelectedUnassigned { get; set; }
    [ObservableProperty] public partial bool HasUnassigned { get; set; }
    [ObservableProperty] public partial IReadOnlyList<Budget> Items { get; set; } = [];
    [ObservableProperty] public partial Budget? Selected { get; set; }
    [ObservableProperty] public partial string Amount { get; set; } = "";
    [ObservableProperty] public partial DateTime? Month { get; set; } = DateTime.Today;
    [ObservableProperty] public partial CategoryType Category { get; set; } = CategoryType.Other;
    public CategoryType[] Categories { get; } = Enum.GetValues<CategoryType>();
    public override async Task RefreshAsync()
    {
        Items = (await service.GetByAccountIdAsync(active.Id)).OrderByDescending(b => b.Year).ThenByDescending(b => b.Month).ToList();
        Amount = "";
        Selected = null;
        Message = Items.Count == 0 ? L.T("Nog geen budgetten ingesteld.") : "";
        Unassigned = (await service.GetAllAsync()).Where(b => b.AccountId is null)
            .Select(b => new UnassignedRecord(b.Id,
                $"{new DateTime(b.Year, b.Month, 1):Y} · {EnumTextConverter.Translate(b.Category)} · {AppCurrency.Format(b.Amount)}")).ToList();
        SelectedUnassigned = null;
        HasUnassigned = Unassigned.Count > 0;
    }
    [RelayCommand] private Task AssignAsync() => RunAsync(async () =>
    {
        if (SelectedUnassigned is not { } record) return;
        var accountId = active.RequireId();
        var legacy = await service.GetByIdAsync(record.Id);
        var existing = await service.GetByAccountIdAsync(accountId);
        if (existing.Any(b => b.Year == legacy!.Year && b.Month == legacy.Month && b.Category == legacy.Category))
        {
            Message = L.Get("LegacyConflict");
            return;
        }
        await service.AssignToAccountAsync(record.Id, accountId);
        await RefreshAsync();
        Message = L.Get("LegacyAssigned");
    });
    [RelayCommand] private Task SaveAsync() => RunAsync(async () =>
    {
        if (Month is not { } date) throw new ArgumentException(L.T("Kies een maand."));
        var amount = Money(Amount);
        var accountId = active.RequireId();
        var existing = (await service.GetByAccountIdAsync(accountId)).FirstOrDefault(b => b.Year == date.Year && b.Month == date.Month && b.Category == Category);
        if (existing is null) await service.CreateAsync(Category, amount, date.Month, date.Year, accountId);
        else await service.UpdateAmountAsync(existing.Id, amount);
        Amount = "";
        await RefreshAsync();
        Message = L.T("Budget opgeslagen.");
    });
    [RelayCommand] private Task DeleteAsync() => RunAsync(async () =>
    {
        if (Selected is null) { Message = L.T("Selecteer eerst een budget."); return; }
        if (!await Shell.Current.DisplayAlertAsync(L.T("Budget verwijderen"), L.T("Dit budget verwijderen?"), L.T("Verwijderen"), L.T("Annuleren"))) return;
        await service.DeleteAsync(Selected.Id); await RefreshAsync();
    });
}
