using BudgetApp.App.Views;
using BudgetApp.Domain.Interfaces.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;

public partial class DashboardViewModel(
    IMonthlyFinanceService monthlyFinanceService,
    IIncomeService incomeService, IAccountService accounts, Services.ActiveAccountState active) : ObservableObject
{
    [ObservableProperty]
    public partial decimal AccountBalance { get; set; }
    [ObservableProperty]
    public partial string MonthLabel { get; set; } = string.Empty;
    [ObservableProperty]
    public partial decimal Income { get; set; }
    [ObservableProperty]
    public partial decimal Expenses { get; set; }
    [ObservableProperty]
    public partial decimal Remaining { get; set; }
    [ObservableProperty]
    public partial decimal RemainingShare { get; set; }
    [ObservableProperty]
    public partial bool HasRemaining { get; set; }
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasExpenseCategories))]
    [NotifyPropertyChangedFor(nameof(HasNoExpenses))]
    public partial IReadOnlyList<ExpenseSlice> ExpenseCategories { get; set; } = [];
    public bool HasExpenseCategories => ExpenseCategories.Count > 0;
    public bool HasNoExpenses => !HasExpenseCategories;
    [ObservableProperty]
    public partial bool IsBusy { get; set; }
    [ObservableProperty]
    public partial bool HasData { get; set; }
    [ObservableProperty]
    public partial bool IsEmpty { get; set; }
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasError))]
    public partial string ErrorMessage { get; set; } = string.Empty;

    public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

    [RelayCommand]
    private async Task LoadAsync()
    {
        IsBusy = true;
        HasData = false;
        IsEmpty = false;
        ErrorMessage = string.Empty;
        try
        {
            var accountId = active.Id;
            await incomeService.EnsureMonthlyTransactionAsync(accountId, DateTime.Today);
            var account = accountId == 0 ? null : await accounts.GetByIdAsync(accountId);
            AccountBalance = account?.Balance ?? 0m;
            var summary = await monthlyFinanceService.GetCurrentMonthSummaryAsync(accountId);
            MonthLabel = new DateTime(summary.Year, summary.Month, 1)
                .ToString("Y", System.Globalization.CultureInfo.CurrentCulture);
            Income = summary.Income;
            Expenses = summary.Expenses;
            ExpenseCategories = summary.ExpenseCategories
                .Select(category => ExpenseSlice.From(category, Math.Max(Income, Expenses))).ToList();
            Remaining = Income - Expenses;
            HasRemaining = Remaining > 0;
            RemainingShare = HasRemaining ? Remaining / Income : 0m;
            IsEmpty = Income == 0 && Expenses == 0;
            HasData = true;
        }
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception);
            ErrorMessage = L.T("Je overzicht kon niet worden geladen. Probeer opnieuw.");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private Task OpenAddTransactionAsync() => Shell.Current.GoToAsync(nameof(AddTransactionPage));
}
