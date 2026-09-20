using BudgetApp.App.ViewModels;

namespace BudgetApp.App.Views;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsViewModel _viewModel;
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    private void OnLanguageChanged(object? sender, EventArgs e)
    {
        if (Window is { } window)
        {
            var shell = new AppShell();
            // Recreate translated pages, preserving the Settings destination.
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
                shell.CurrentItem = shell.Items.First(item => item.Route == "SettingsDesktop");
            else
            {
                var root = shell.Items.FirstOrDefault(item => item is TabBar);
                var more = root?.Items.FirstOrDefault(section => section.Route == "MoreMobile");
                if (root is not null && more is not null)
                {
                    more.CurrentItem = more.Items.First(content => content.Route == "SettingsMobile");
                    root.CurrentItem = more;
                    shell.CurrentItem = root;
                }
            }
            window.Page = shell;
        }
    }

    protected override void OnDisappearing()
    {
        _viewModel.LanguageChanged -= OnLanguageChanged;
        base.OnDisappearing();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LanguageChanged += OnLanguageChanged;
    }
}
