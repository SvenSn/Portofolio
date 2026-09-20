namespace BudgetApp.Domain.Entities;

public class Income
{
    public int? AccountId { get; private set; }

    public void AssignToAccount(int accountId)
    {
        if (accountId <= 0) throw new ArgumentOutOfRangeException(nameof(accountId));
        if (AccountId is not null) throw new InvalidOperationException("Already assigned to an account.");
        AccountId = accountId;
    }
    public int Id { get; private set; }

    public decimal Amount
    {
        get;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Inkomen moet groter zijn dan 0.");

            field = value;
        }
    }

    public DateTime EffectiveFrom { get; private set; }

    private Income()
    {
        // Voor EF Core
    }

    public Income(decimal amount, DateTime effectiveFrom)
    {
        Amount = amount;
        EffectiveFrom = effectiveFrom;
    }

    public void UpdateAmount(decimal amount)
        => Amount = amount;

    public void UpdateEffectiveFrom(DateTime effectiveFrom)
        => EffectiveFrom = effectiveFrom;
}
