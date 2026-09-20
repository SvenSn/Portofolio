using BudgetApp.App.ViewModels;
using BudgetApp.App.Views;
using BudgetApp.Domain.Interfaces.Repositories;
using BudgetApp.Domain.Interfaces.Services;
using BudgetApp.Domain.Services;
using BudgetApp.Infrastructure.Data;
using BudgetApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;

namespace BudgetApp.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font Awesome 7 Free-Solid-900.otf", "FontAwesomeSolid");
                fonts.AddFont("Font Awesome 7 Free-Regular-400.otf", "FontAwesomeRegular");
            });
        
        // Databasefactory: elke repositorybewerking maakt een eigen context.
        var databasePath = Path.Combine(
            FileSystem.AppDataDirectory,
            "budgetapp.db");


        builder.Services.AddDbContextFactory<BudgetDbContext>(
            options => options.UseSqlite($"Data Source={databasePath}"));


        // Repositories
        builder.Services.AddTransient<IAccountRepository, AccountRepository>();
        builder.Services.AddTransient<IBudgetRepository, BudgetRepository>();
        builder.Services.AddTransient<ISavingsGoalRepository, SavingsGoalRepository>();
        builder.Services.AddTransient<IIncomeRepository, IncomeRepository>();
        builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();


        // Services
        builder.Services.AddSingleton<BudgetApp.App.Services.ActiveAccountState>();
        builder.Services.AddTransient<IBudgetService, BudgetService>();
        builder.Services.AddTransient<ISavingsGoalService, SavingsGoalService>();
        builder.Services.AddTransient<IIncomeService, IncomeService>();
        builder.Services.AddTransient<ITransactionService, TransactionService>();
        builder.Services.AddTransient<IAccountService, AccountService>();
        builder.Services.AddTransient<IMonthlyFinanceService, MonthlyFinanceService>();

        // ViewModels
        builder.Services.AddTransient<AccountsViewModel>();
        builder.Services.AddTransient<IncomeViewModel>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<AddTransactionViewModel>();
        builder.Services.AddTransient<BudgetsViewModel>();
        builder.Services.AddTransient<SavingsGoalViewModel>();
        builder.Services.AddTransient<SavingsViewModel>();
        builder.Services.AddTransient<HistoryViewModel>();
        builder.Services.AddTransient<MonthlyDetailsViewModel>();
        builder.Services.AddTransient<TransactionsViewModel>();
        builder.Services.AddTransient<CreateNewAccountViewModel>();


        // Pages
        builder.Services.AddTransient<AccountsPage>();
        builder.Services.AddTransient<IncomePage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<AddTransactionPage>();
        builder.Services.AddTransient<MonthlyDetailsPage>();
        builder.Services.AddTransient<BudgetsPage>();
        builder.Services.AddTransient<SavingsGoalPage>();
        builder.Services.AddTransient<SavingsPage>();
        builder.Services.AddTransient<HistoryPage>();
        builder.Services.AddTransient<TransactionPage>();
        builder.Services.AddTransient<CreateNewAccountPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        // Maak de database en tabellen aan als ze nog niet bestaan.
        var contextFactory = app.Services
            .GetRequiredService<IDbContextFactory<BudgetDbContext>>();

        using (var database = contextFactory.CreateDbContext())
        {
            DatabaseInitializer.Initialize(database);
        }

        return app;
    }
}
