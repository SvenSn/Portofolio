using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;

public abstract partial class ScreenViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsReady))]
    public partial bool IsBusy { get; set; }
    [ObservableProperty]
    public partial string Message { get; set; } = string.Empty;
    public bool IsReady => !IsBusy;
    public abstract Task RefreshAsync();

    protected async Task RunAsync(Func<Task> action)
    {
        if (IsBusy) return;
        IsBusy = true;
        Message = string.Empty;
        try { await action(); }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            Message = ex is ArgumentException validation ? L.ValidationMessage(validation) : L.T("De actie is mislukt. Probeer opnieuw.");
        }
        finally { IsBusy = false; }
    }

    [RelayCommand]
    private Task LoadAsync() => RunAsync(RefreshAsync);

    protected static decimal Money(string text, bool zeroAllowed = false)
    {
        if (!decimal.TryParse(text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite |
            NumberStyles.AllowTrailingWhite, CultureInfo.CurrentCulture, out var value) ||
            value < 0 || (!zeroAllowed && value == 0) || decimal.Round(value, 2) != value)
            throw new ArgumentException(L.T("Vul een geldig bedrag in met maximaal twee decimalen."));
        return value;
    }
}
