using System.Globalization;

namespace BudgetApp.App.Localization;

public static class SystemValueFormatter
{
    public static string Format(string format, params object[] values) =>
        string.Format(CultureInfo.CurrentCulture, format, values);
}
