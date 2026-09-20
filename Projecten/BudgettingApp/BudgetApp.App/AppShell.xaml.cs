using BudgetApp.App.Views;

namespace BudgetApp.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(CreateNewAccountPage), typeof(CreateNewAccountPage));

        Routing.RegisterRoute(
            nameof(SettingsPage),
            typeof(SettingsPage));

        Routing.RegisterRoute(
            nameof(AddTransactionPage),
            typeof(AddTransactionPage));

        Routing.RegisterRoute(
            nameof(MonthlyDetailsPage),
            typeof(MonthlyDetailsPage));

        Routing.RegisterRoute(
            nameof(SavingsGoalPage),
            typeof(SavingsGoalPage));
    }
}
