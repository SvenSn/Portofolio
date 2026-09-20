using BudgetApp.App.ViewModels;

namespace BudgetApp.App.Views;

public partial class CreateNewAccountPage : ContentPage
{
    private readonly CreateNewAccountViewModel _viewModel;

    public CreateNewAccountPage(CreateNewAccountViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _viewModel.AccountCreated += OnAccountCreated;
    }

    protected override void OnDisappearing()
    {
        _viewModel.AccountCreated -= OnAccountCreated;

        base.OnDisappearing();
    }

    private async void OnAccountCreated(object? sender, EventArgs e)
    {
        if (Window is { } window)
        {
            if (window.Page is Shell shell && shell.Navigation.NavigationStack.Count > 1)
                await shell.GoToAsync("..");
            else
                window.Page = new AppShell();
        }
    }
}
