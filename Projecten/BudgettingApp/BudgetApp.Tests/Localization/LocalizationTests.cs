using System.Globalization;
using BudgetApp.App.Localization;

namespace BudgetApp.Tests;

public sealed class LocalizationTests
{
    [Fact]
    public void EnglishAndDutchResourcesAreAvailable()
    {
        Assert.Equal("Instellingen", TextResources.Get("Text041", false));
        Assert.Equal("Settings", TextResources.Get("Text041", true));
    }

    [Theory]
    [InlineData("nl-BE")]
    [InlineData("en-US")]
    public void FormattingUsesDeviceCulture(string cultureName)
    {
        var previous = CultureInfo.CurrentCulture;
        try
        {
            var culture = CultureInfo.GetCultureInfo(cultureName);
            CultureInfo.CurrentCulture = culture;
            Assert.Equal("€ " + 1234.56m.ToString("N2", culture), SystemValueFormatter.Format("€ {0:N2}", 1234.56m));
        }
        finally { CultureInfo.CurrentCulture = previous; }
    }
}
