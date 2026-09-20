using BudgetApp.App.Localization;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces.Services;

namespace BudgetApp.App.Services;

// One selection for the entire app, not a separate selection per tab.
public sealed class ActiveAccountState(IAccountService accounts)
{
    private const string PreferenceKey = "ActiveAccountId";
    public IReadOnlyList<Account> Accounts { get; private set; } = [];
    public Account? Current { get; private set; }
    public event EventHandler? Changed;
    // Zero deliberately matches no account; it never means "all accounts".
    public int Id => Current?.Id ?? 0;

    public async Task RefreshAsync()
    {
        var preferredId = Current?.Id ?? Preferences.Default.Get(PreferenceKey, 0);
        Accounts = (await accounts.GetAllAsync()).OrderBy(a => a.Name).ToList();
        Select(Accounts.FirstOrDefault(a => a.Id == preferredId) ?? Accounts.FirstOrDefault());
    }

    public void Select(Account? account)
    {
        Current = account is null ? null : Accounts.FirstOrDefault(a => a.Id == account.Id);
        if (Current is null) Preferences.Default.Remove(PreferenceKey);
        else Preferences.Default.Set(PreferenceKey, Current.Id);
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public int RequireId() => Current?.Id ?? throw new ArgumentException(L.Get("SelectAccountFirst"));
}
