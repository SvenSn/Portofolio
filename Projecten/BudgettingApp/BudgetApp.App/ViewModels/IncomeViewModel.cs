using System.Collections.ObjectModel;
using System.Globalization;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;

public partial class IncomeViewModel(IIncomeService incomeService, Services.ActiveAccountState active) : ObservableObject
{
    private int _loadedAccountId;
    [ObservableProperty] public partial IReadOnlyList<UnassignedRecord> Unassigned { get; set; } = [];
    [ObservableProperty] public partial UnassignedRecord? SelectedUnassigned { get; set; }
    [ObservableProperty] public partial bool HasUnassigned { get; set; }
    public ObservableCollection<Income> Incomes { get; } = [];

    [ObservableProperty]
    public partial string Amount { get; set; } = string.Empty;
    [ObservableProperty]
    public partial DateTime? EffectiveFrom { get; set; } = DateTime.Today;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [NotifyCanExecuteChangedFor(nameof(LoadCommand))]
    [NotifyCanExecuteChangedFor(nameof(AssignCommand))]
    public partial bool IsBusy { get; set; }
    [ObservableProperty]
    public partial string Message { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string CurrentIncome { get; set; } = L.T("Nog niet geladen");
    [ObservableProperty]
    public partial bool IsEmpty { get; set; }

    private bool CanRun() => !IsBusy;

    private async Task RefreshAsync()
    {
        var accountId = active.Id;
        if (_loadedAccountId != accountId)
        {
            Amount = string.Empty;
            EffectiveFrom = DateTime.Today;
            _loadedAccountId = accountId;
        }
        await incomeService.EnsureMonthlyTransactionAsync(accountId, DateTime.Today);
        var incomes = await incomeService.GetByAccountIdAsync(accountId);
        Incomes.Clear();
        foreach (var income in incomes.OrderByDescending(i => i.EffectiveFrom).ThenByDescending(i => i.Id))
            Incomes.Add(income);
        var current = Incomes.FirstOrDefault(i => i.EffectiveFrom.Date <= DateTime.Today);
        CurrentIncome = current is null ? L.T("Nog geen geldig inkomen") : AppCurrency.Format(current.Amount);
        IsEmpty = Incomes.Count == 0;
        Unassigned = (await incomeService.GetAllAsync()).Where(i => i.AccountId is null)
            .Select(i => new UnassignedRecord(i.Id, $"{i.EffectiveFrom:d} · {AppCurrency.Format(i.Amount)}")).ToList();
        SelectedUnassigned = null;
        HasUnassigned = Unassigned.Count > 0;
    }

    [RelayCommand(CanExecute = nameof(CanRun))]
    private async Task AssignAsync()
    {
        if (SelectedUnassigned is not { } record) return;
        IsBusy = true;
        try
        {
            var accountId = active.RequireId();
            var legacy = await incomeService.GetByIdAsync(record.Id);
            var existing = await incomeService.GetByAccountIdAsync(accountId);
            if (existing.Any(i => i.EffectiveFrom.Date == legacy!.EffectiveFrom.Date))
            {
                Message = L.Get("LegacyConflict");
                return;
            }
            await incomeService.AssignToAccountAsync(record.Id, accountId);
            await RefreshAsync();
            Message = L.Get("LegacyAssigned");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            Message = L.T("De actie is mislukt. Probeer opnieuw.");
        }
        finally { IsBusy = false; }
    }

    [RelayCommand(CanExecute = nameof(CanRun))]
    private async Task LoadAsync()
    {
        IsBusy = true;
        Message = string.Empty;
        try { await RefreshAsync(); }
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception);
            Message = L.T("Het inkomen kon niet worden geladen. Probeer opnieuw.");
        }
        finally { IsBusy = false; }
    }

    [RelayCommand(CanExecute = nameof(CanRun))]
    private async Task SaveAsync()
    {
        Message = string.Empty;
        if (!decimal.TryParse(Amount,
            NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
            CultureInfo.CurrentCulture, out var amount) || amount <= 0 || decimal.Round(amount, 2) != amount)
        {
            Message = L.T("Vul een bedrag groter dan nul in met maximaal twee decimalen.");
            return;
        }
        if (EffectiveFrom is not { } date)
        {
            Message = L.T("Kies een ingangsdatum.");
            return;
        }
        IsBusy = true;
        try
        {
            var accountId = active.RequireId();
            var existing = await incomeService.GetByAccountIdAsync(accountId);
            if (existing.Any(income => income.EffectiveFrom.Date == date.Date))
            {
                Message = L.T("Er bestaat al een inkomen met deze ingangsdatum. Kies een andere datum.");
                IsBusy = false;
                return;
            }
            await incomeService.CreateAsync(amount, date.Date, accountId);
        }
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception);
            Message = L.T("Opslaan is mislukt. Probeer opnieuw.");
            IsBusy = false;
            return;
        }
        Amount = string.Empty;
        try
        {
            await RefreshAsync();
            Message = L.T("Je inkomen is opgeslagen.");
        }
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception);
            Message = L.T("Opgeslagen, maar het overzicht kon niet worden vernieuwd. Klik op Vernieuwen.");
        }
        finally { IsBusy = false; }
    }
}
