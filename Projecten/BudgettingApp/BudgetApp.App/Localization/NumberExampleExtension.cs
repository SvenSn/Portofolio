using System.Globalization;
namespace BudgetApp.App.Localization;

public sealed class NumberExampleExtension : IMarkupExtension<string>
{
    public double Value { get; set; }
    public bool Example { get; set; }
    public string ProvideValue(IServiceProvider serviceProvider) =>
        Example ? L.Format("Bijvoorbeeld: {0:N2}", Value) : Value.ToString("N2", CultureInfo.CurrentCulture);
    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
