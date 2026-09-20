using BudgetApp.Domain.Enums;
using BudgetApp.Domain.Interfaces.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;

using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;

public partial class CreateNewAccountViewModel : ObservableObject
{
    private readonly IAccountService _accountService;

    public CreateNewAccountViewModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public AccountType[] AccountTypes { get; } = Enum.GetValues<AccountType>();

    [ObservableProperty]
    public partial string Name { get; set; } = string.Empty;

    [ObservableProperty]
    public partial AccountType SelectedAccountType { get; set; } = AccountType.Checking;

    [ObservableProperty]
    public partial string OpeningBalance { get; set; } = "0";

    [ObservableProperty]
    public partial bool IsBusy { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasError))]
    public partial string ErrorMessage { get; set; } = string.Empty;

    public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);

    public event EventHandler? AccountCreated;

    [RelayCommand]
    private async Task CreateAccountAsync()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Name))
        {
            ErrorMessage = L.T("Vul een rekeningnaam in.");
            return;
        }

        if (!decimal.TryParse(
                OpeningBalance,
                NumberStyles.AllowLeadingSign |
                NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowLeadingWhite |
                NumberStyles.AllowTrailingWhite,
                CultureInfo.CurrentCulture,
                out var balance))
        {
            ErrorMessage =
                L.T("Vul een geldig beginsaldo in volgens je toestelinstellingen.");
            return;
        }

        if (!Enum.IsDefined(SelectedAccountType))
        {
            ErrorMessage = L.T("Kies een rekeningtype.");
            return;
        }

        IsBusy = true;

        try
        {
            await _accountService.CreateAsync(
                Name.Trim(),
                SelectedAccountType,
                balance);
        }
        catch (Exception)
        {
            ErrorMessage =
                L.T("De rekening kon niet worden opgeslagen. Probeer opnieuw.");
            return;
        }
        finally
        {
            IsBusy = false;
        }

        AccountCreated?.Invoke(this, EventArgs.Empty);
    }
}
