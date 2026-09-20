# BudgetApp for Android

Manage accounts, income, expenses, budgets and savings goals on your Android device.

## APK and installation

Use `com.companyname.budgetapp.app-Signed.apk`. This is a Release test build signed with a local development key. It is not a Google Play release.

1. Copy the APK to your Android device.
2. Open it from the file manager or download notification.
3. Allow the file manager to install unknown apps if Android asks.
4. Confirm the installation and open BudgetApp.

Install only APK files from a trusted source. Use the signed APK, not the unsigned file.

## First use

Create a financial account with a name, type and opening balance. Select an active account on a financial page. This selection controls the dashboard, chart, transactions, income, budgets, savings goals and history, and is remembered after restart.

Settings lets you choose EUR, USD, GBP, AUD or CAD. This changes the displayed currency for all amounts. Exchange rates are not applied.

Additional pages such as Accounts, Income, History and Settings are under **More** on mobile. Existing records without an account are shown under **Unassigned** and are excluded from account totals until linked.

## Important calculations

- **Account balance:** opening balance plus recorded transactions.
- **Configured income:** a monthly amount with an effective date. It is posted as an income transaction on the same day each month and then increases the balance.
- **Monthly result:** recorded income transactions minus expenses.
- **Pie chart:** expenses by category and, where applicable, the remaining amount.
- **Savings contributions:** track progress and do not move money.

## Updates and data

Settings supports Dutch and English, and light and dark themes. Dates and number formatting follow device settings.

Data is stored locally. Removing the app or clearing its storage can remove budget data. An account deletion also deletes its linked transactions, income, budgets and savings goals after confirmation.

This test APK uses a development key. A future APK signed with another key cannot update this installation directly. For distribution, use a private keystore and keep it safe outside Git.

## Troubleshooting

For installation conflicts, check whether an older version uses another signing key. Do not uninstall the old app before securing your data. If data appears missing, check the active account, month and Unassigned section.

See also: [Dutch Android guide](README-Android.nl.md), [project README](../../README.en.md).
