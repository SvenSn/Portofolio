namespace BudgetApp.App.Localization;

public static class AppLanguage
{
    public const string Dutch = "Nederlands";
    public const string English = "English";
    public static string Current { get; set; } = Dutch;
    public static bool IsEnglish => Current == English;
}
