using System.Globalization;

namespace BudgetApp.App.Localization;

public static class AppCurrency
{
    public static string Symbol { get; set; } = "€";
    public static string Format(decimal value) => $"{Symbol} {value.ToString("N2", CultureInfo.CurrentCulture)}";
}
