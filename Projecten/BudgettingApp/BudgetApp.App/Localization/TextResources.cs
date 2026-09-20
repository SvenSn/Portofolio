using System.Globalization;
using System.Resources;

namespace BudgetApp.App.Localization;

public static class TextResources
{
    private static readonly ResourceManager Resources =
        new("BudgetApp.App.Resources.Strings.AppStrings", typeof(TextResources).Assembly);

    public static string Get(string key, bool english) =>
        Resources.GetString(key, CultureInfo.GetCultureInfo(english ? "en" : "nl")) ?? key;
}
