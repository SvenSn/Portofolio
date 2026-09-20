using BudgetApp.App.Views;
using BudgetApp.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

using BudgetApp.App.Localization;

namespace BudgetApp.App;

public partial class App : Application
{
    private readonly IAccountService _accountService;
    private readonly IServiceProvider _services;

    public App(
        IAccountService accountService,
        IServiceProvider services)
    {
        InitializeComponent();
        UserAppTheme = Preferences.Default.Get("AppTheme", "Licht") == "Donker"
            ? AppTheme.Dark : AppTheme.Light;

        _accountService = accountService;
        _services = services;
    }

    protected override Window CreateWindow(
        IActivationState? activationState)
    {
        var loadingPage = new ContentPage
        {
            Content = new VerticalStackLayout
            {
                Spacing = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    new ActivityIndicator
                    {
                        IsRunning = true,
                        HorizontalOptions = LayoutOptions.Center
                    },

                    new Label
                    {
                        Text = L.T("Rekeningen laden..."),
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            }
        };

        var window = new Window(loadingPage);

        loadingPage.Loaded += OnLoaded;

        return window;

        void OnLoaded(object? sender, EventArgs e)
        {
            loadingPage.Loaded -= OnLoaded;

            // Android can still be walking its child views during Loaded.
            // SQLite async calls may complete synchronously, so await alone
            // does not make replacing the root page safe here.
            loadingPage.Dispatcher.Dispatch(async () => await InitializeStartupAsync());
        }

        async Task InitializeStartupAsync()
        {
            try
            {
                var accounts = await _accountService.GetAllAsync();

                if (window.Page != loadingPage)
                    return;

                window.Page = accounts.Count == 0
                    ? _services.GetRequiredService<CreateNewAccountPage>()
                    : new AppShell();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                await loadingPage.DisplayAlertAsync(
                    L.T("Laden mislukt"),
                    L.T("De rekeningen konden niet worden geladen. Herstart de app om opnieuw te proberen."),
                    L.T("OK"));
            }
        }
    }
}
