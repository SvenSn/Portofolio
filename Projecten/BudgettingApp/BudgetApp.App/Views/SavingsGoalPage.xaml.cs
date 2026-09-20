using BudgetApp.App.Controls;
using BudgetApp.App.Services;
using BudgetApp.App.ViewModels;

namespace BudgetApp.App.Views;

public partial class SavingsGoalPage : ContentPage
{
    private readonly AccountPageController _accountPage;

    public SavingsGoalPage(SavingsGoalViewModel viewModel, ActiveAccountState active)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _accountPage = new AccountPageController(this, active, viewModel,
            viewModel.LoadCommand, () => viewModel.IsBusy);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _accountPage.AppearAsync();
    }

    protected override void OnDisappearing()
    {
        _accountPage.Disappear();
        base.OnDisappearing();
    }
}
