using System.Globalization;
using BudgetApp.Domain.Enums;

namespace BudgetApp.App.Localization;

// Alleen de weergave wordt vertaald; SelectedItem blijft de oorspronkelijke enum.
public sealed class EnumTextConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => Translate(value);

    public static string Translate(object? value)
    {
        var english = AppLanguage.IsEnglish;
        return value switch
        {
            CategoryType.Housing => english ? "Housing" : "Wonen",
            CategoryType.Transportation => english ? "Transport" : "Vervoer",
            CategoryType.Food => english ? "Food" : "Voeding",
            CategoryType.Utilities => english ? "Utilities" : "Nutsvoorzieningen",
            CategoryType.Salary => english ? "Salary" : "Loon",
            CategoryType.Entertainment => english ? "Entertainment" : "Ontspanning",
            CategoryType.Subscriptions => english ? "Subscriptions" : "Abonnementen",
            CategoryType.Healthcare => english ? "Healthcare" : "Gezondheidszorg",
            CategoryType.Other => english ? "Other" : "Overige",
            TransactionType.Income => english ? "Income" : "Inkomst",
            TransactionType.Expense => english ? "Expense" : "Uitgave",
            AccountType.Checking => english ? "Current account" : "Zichtrekening",
            AccountType.Savings => english ? "Savings account" : "Spaarrekening",
            AccountType.CreditCard => english ? "Credit card" : "Kredietkaart",
            _ => value?.ToString() ?? string.Empty
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
