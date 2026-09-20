# BudgetApp for Windows

Manage accounts, income, expenses, budgets and savings goals in one place.

## Installation

1. Download `BudgetApp-windows-x64.zip`.
2. Extract the ZIP completely to its own folder.
3. Start `BudgetApp.App.exe`.

Keep the complete folder together. Do not run the application from inside the ZIP or copy only the EXE. This is an unpackaged self-contained Windows x64 application, not an installer.

## First use

Create a financial account with a name, type and opening balance. Select an active account on a financial page. The active account controls the dashboard, chart, transactions, income, budgets, savings goals and history. The selection is remembered after restarting.

Settings lets you choose EUR, USD, GBP, AUD or CAD. This changes the displayed currency for all amounts. Exchange rates are not applied.

Existing records without an account are shown under **Unassigned** and are excluded from account totals until you link them.

## Important calculations

- **Account balance:** opening balance plus recorded income and expense transactions.
- **Configured income:** a monthly amount with an effective date. It is posted as an income transaction on the same day each month and then increases the balance.
- **Monthly result:** recorded income transactions minus that month's expenses.
- **Savings contributions:** track goal progress and do not transfer money.

The app prevents duplicate automatic postings per month. The posting is created when the app is opened on or after the payment day.

## Language, theme and data

Settings supports Dutch and English, and light and dark themes. Dates and number formatting follow the device settings.

Data is stored locally in the SQLite database `budgetapp.db`. Windows and Android do not synchronize automatically. Back up data while the app is closed.

Deleting an account also deletes its linked transactions, income records, budgets and savings goals after confirmation. This cannot be undone.

## Troubleshooting

If the app does not start, extract the complete ZIP again and confirm that you are using Windows x64. If data appears missing, check the active account, month and Unassigned section.

Do not share database files, passwords or personal financial data when reporting a problem.

See also: [Dutch Windows guide](README-Windows.nl.md), [project README](../../README.en.md).
