using System.Globalization;

namespace BudgetApp.App.Localization;

/// <summary>Formats with the device culture, regardless of the selected UI language.</summary>
public sealed class LocalizedValueConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null) return string.Empty;
        if (value is bool completed) return L.T(completed ? "Behaald" : "Nog bezig");
        var format = parameter?.ToString() ?? "{0}";
        format = format switch
        {
            "Money" => $"{AppCurrency.Symbol} {{0:N2}}",
            "Date" => "{0:d}",
            "Percent" => "{0:P1}",
            _ => format
        };
        if (format.StartsWith("Text", StringComparison.Ordinal)) format = L.Get(format);
        if (format.Contains('€')) format = format.Replace("€", AppCurrency.Symbol, StringComparison.Ordinal);
        return SystemValueFormatter.Format(format, value);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}
