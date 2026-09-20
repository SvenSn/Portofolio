using CommunityToolkit.Mvvm.ComponentModel;
using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Entities;
using CommunityToolkit.Mvvm.Input;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;

public partial class AddTransactionViewModel(ITransactionService transactions, Services.ActiveAccountState active) : ScreenViewModel, IQueryAttributable
{
    private int? _loadedAccountId;
    private int? _editingId;
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var raw) && int.TryParse(raw.ToString(), out var id)) _editingId = id;
    }
    [ObservableProperty] public partial IReadOnlyList<Account> Accounts { get; set; } = [];
    [ObservableProperty] public partial Account? SelectedAccount { get; set; }
    [ObservableProperty] public partial string Amount { get; set; } = "";
    [ObservableProperty] public partial string Description { get; set; } = "";
    [ObservableProperty] public partial DateTime? Date { get; set; } = DateTime.Today;
    [ObservableProperty] public partial TransactionType Type { get; set; } = TransactionType.Expense;
    [ObservableProperty] public partial CategoryType Category { get; set; } = CategoryType.Other;
    public TransactionType[] Types { get; } = Enum.GetValues<TransactionType>();
    public CategoryType[] Categories { get; } = Enum.GetValues<CategoryType>();
    public override async Task RefreshAsync()
    {
        var accountId = active.Id;
        if (_loadedAccountId is { } previous && previous != accountId)
        {
            _editingId = null;
            Amount = "";
            Description = "";
            Date = DateTime.Today;
            Type = TransactionType.Expense;
            Category = CategoryType.Other;
        }
        _loadedAccountId = accountId;
        Accounts = active.Accounts;
        SelectedAccount = active.Current;
        if (_editingId is { } id)
        {
            var transaction = await transactions.GetByIdAsync(id)
                ?? throw new ArgumentException(L.T("Transactie niet gevonden."));
            if (transaction.AccountId != accountId)
            {
                _editingId = null;
                throw new ArgumentException(L.T("Transactie niet gevonden."));
            }
            SelectedAccount = Accounts.FirstOrDefault(a => a.Id == transaction.AccountId);
            Amount = transaction.Amount.ToString(System.Globalization.CultureInfo.CurrentCulture);
            Description = transaction.Description; Date = transaction.Date;
            Type = transaction.Type; Category = transaction.Category;
            Message = L.T("Transactie bewerken. De oorspronkelijke rekening blijft behouden.");
        }
        if (Accounts.Count == 0) Message = L.T("Maak eerst een rekening aan.");
    }
    [RelayCommand]
    private Task SaveAsync() => RunAsync(async () =>
    {
        if (SelectedAccount is null || Date is null || string.IsNullOrWhiteSpace(Description))
            throw new ArgumentException(L.T("Kies een rekening en datum en vul een omschrijving in."));
        if (_editingId is { } id)
            await transactions.UpdateAsync(id, Money(Amount), Date.Value.Date, Description.Trim(), Type, Category);
        else
            await transactions.CreateAsync(Money(Amount), Date.Value.Date, Description.Trim(), Type, Category, SelectedAccount.Id);
        _editingId = null;
        Amount = ""; Description = "";
        Message = L.T("Transactie opgeslagen.");
    });
}
