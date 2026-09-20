using CommunityToolkit.Mvvm.ComponentModel;
using BudgetApp.App.Localization;

namespace BudgetApp.App.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    public string PreferencesTitle => L.T("Jouw voorkeuren");
    public string PreferencesDescription => L.T("Maak de app prettig voor jou. Je keuze wordt automatisch bewaard.");
    public string AppearanceTitle => L.T("Weergave");
    public string ThemeLabel => L.T("Thema");
    public string LanguageLabel => L.T("Taal");
    public string FormatDescription => L.T("Datums en getallen volgen je toestelinstellingen.");
    public string CurrencyLabel => L.T("Valuta");

    public IReadOnlyList<string> Themes { get; } = [L.T("Licht"), L.T("Donker")];
    public IReadOnlyList<string> Languages { get; } = [AppLanguage.Dutch, AppLanguage.English];
    public IReadOnlyList<string> Currencies { get; } = AppCurrency.Options;

    [ObservableProperty]
    public partial string SelectedLanguage { get; set; } = AppLanguage.Dutch;

    [ObservableProperty]
    public partial string SelectedTheme { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string SelectedCurrency { get; set; } = "EUR";

    public SettingsViewModel()
    {
        // Persist stable values, independent of the displayed translation.
        var dark = Preferences.Default.Get("AppTheme", "Licht") == "Donker";
        SelectedTheme = L.T(dark ? "Donker" : "Licht");
        SelectedLanguage = AppLanguage.Current;
        SelectedCurrency = AppCurrency.Current;
    }

    partial void OnSelectedLanguageChanged(string value)
    {
        if (!Languages.Contains(value) || value == AppLanguage.Current) return;
        AppLanguage.Current = value;
        LanguageChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? LanguageChanged;

    partial void OnSelectedCurrencyChanged(string value)
    {
        if (!Currencies.Contains(value)) return;
        AppCurrency.Current = value;
        CurrencyChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? CurrencyChanged;

    partial void OnSelectedThemeChanged(string value)
    {
        if (string.IsNullOrEmpty(value)) return;
        var dark = value == L.T("Donker");
        Preferences.Default.Set("AppTheme", dark ? "Donker" : "Licht");
        if (Application.Current is { } app)
            app.UserAppTheme = dark ? AppTheme.Dark : AppTheme.Light;
    }
}
