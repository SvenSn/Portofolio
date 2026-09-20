namespace BudgetApp.App.Localization;

public static class AppLanguage
{
    public const string Dutch = "Nederlands";
    public const string English = "English";
    private const string PreferenceKey = "AppLanguage";

    public static string Current
    {
        get => Preferences.Default.Get(PreferenceKey, Dutch);
        set => Preferences.Default.Set(PreferenceKey, value);
    }

    public static bool IsEnglish => Current == English;
}
