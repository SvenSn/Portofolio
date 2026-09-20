namespace BudgetApp.App.Localization;

[ContentProperty(nameof(Key))]
public sealed class TranslateExtension : IMarkupExtension<string>
{
    public string Key { get; set; } = string.Empty;
    public string ProvideValue(IServiceProvider serviceProvider) => L.Get(Key);
    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
