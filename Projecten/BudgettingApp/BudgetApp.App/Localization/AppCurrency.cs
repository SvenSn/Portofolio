namespace BudgetApp.App.Localization;

public static class AppCurrency
{
    private const string PreferenceKey = "AppCurrency";
    public static IReadOnlyList<string> Options { get; } = ["EUR", "USD", "GBP", "AUD", "CAD"];

    public static string Current
    {
        get
        {
            var value = Preferences.Default.Get(PreferenceKey, "EUR");
            return Options.Contains(value) ? value : "EUR";
        }
        set
        {
            if (Options.Contains(value)) Preferences.Default.Set(PreferenceKey, value);
        }
    }

    public static string Symbol => Current switch
    {
        "USD" => "$",
        "GBP" => "£",
        "AUD" => "A$",
        "CAD" => "C$",
        _ => "€"
    };

    public static string Format(decimal value) =>
        $"{Symbol} {value.ToString("N2", System.Globalization.CultureInfo.CurrentCulture)}";
}
