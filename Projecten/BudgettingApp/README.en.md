# BudgetApp

A budgeting app in C# 14 and .NET 10 MAUI for accounts, income, expenses, budgets and savings goals.

## Features

Settings supports EUR (euro), USD (US dollar), GBP (British pound), AUD (Australian dollar) and CAD (Canadian dollar). The selected currency is applied to all monetary values. Only the display changes; exchange rates are not applied.

- Multiple financial accounts with opening balance and account type.
- One active account for the dashboard, chart, transactions, income, budgets, savings goals and history.
- Create, edit and delete transactions.
- Record income with an effective date.
- Budgets per category and month.
- Create, edit, delete and update savings goals.
- Dashboard with account balance, monthly result and expense chart.
- Dutch and English interface, with light and dark themes.
- Local SQLite storage.

The account balance is the opening balance plus recorded transactions. Configured income does not change the balance; it is used in the monthly result. A savings-goal contribution does not transfer money.

## Project structure

| Project | Purpose |
| --- | --- |
| `BudgetApp.App` | MAUI views, viewmodels, navigation, localization and styling. |
| `BudgetApp.Domain` | Entities, enums, interfaces and business logic. |
| `BudgetApp.Infrastructure` | EF Core, SQLite, database initialization and repositories. |
| `BudgetApp.Tests` | Tests for storage, account isolation, balances and localization. |

The app uses MVVM and dependency injection. Repositories create a separate context per operation through `IDbContextFactory<BudgetDbContext>`.

## Requirements

- .NET 10 SDK.
- Visual Studio with the .NET MAUI workload.
- Windows SDK for Windows.
- Android SDK and JDK for Android.

Open `BudgetApp.sln`, set `BudgetApp.App` as the startup project, and choose Windows or an Android emulator/device.

## Build and test

Run from the repository root:

```powershell
dotnet build .\\BudgetApp.App\\BudgetApp.App.csproj -f net10.0-windows10.0.19041.0
dotnet build .\\BudgetApp.App\\BudgetApp.App.csproj -f net10.0-android
dotnet test .\\BudgetApp.Tests\\BudgetApp.Tests.csproj
```

The tests use temporary in-memory SQLite databases.

## Publishing

Publish the MAUI project, not the entire solution. See the [Windows guide](docs/distribution/README-Windows.en.md) and [Android guide](docs/distribution/README-Android.en.md).

The Android test APK uses a development key. A private keystore is required for distribution; keep it outside Git and use the same key for updates.

## Database and warnings

The database is named `budgetapp.db` and stored in `FileSystem.AppDataDirectory`. Windows and Android do not synchronize automatically.

Existing income, budget and savings-goal records without an account remain unassigned until the user chooses an account. Deleting an account also deletes its linked transactions, income records, budgets and savings goals.

Back up data while the app is closed. Never share a database, keystore, password or personal financial data.

## Documentation in Dutch

- [Nederlandse project-README](README.nl.md)
- [Nederlandse Windows-handleiding](docs/distribution/README-Windows.nl.md)
- [Nederlandse Android-handleiding](docs/distribution/README-Android.nl.md)
