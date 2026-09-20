using BudgetApp.Domain.Enums;

namespace BudgetApp.Domain.Entities;

public class Budget
{
    public int? AccountId { get; private set; }

    public void AssignToAccount(int accountId)
    {
        if (accountId <= 0) throw new ArgumentOutOfRangeException(nameof(accountId));
        if (AccountId is not null) throw new InvalidOperationException("Already assigned to an account.");
        AccountId = accountId;
    }
    public int Id { get; private set; }

    public CategoryType Category { get; private set; }

    public decimal Amount
    {
        get;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Budgetbedrag moet groter zijn dan 0.");

            field = value;
        }
    }

    public int Month
    {
        get;
        private set
        {
            if (value is < 1 or > 12)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Maand moet tussen 1 en 12 liggen.");

            field = value;
        }
    }

    public int Year
    {
        get;
        private set
        {
            if (value < 2000)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Jaar is ongeldig.");

            field = value;
        }
    }

    private Budget()
    {
        // Voor EF Core
    }

    public Budget(
        CategoryType category,
        decimal amount,
        int month,
        int year)
    {
        Category = category;
        Amount = amount;
        Month = month;
        Year = year;
    }

    public void UpdateAmount(decimal amount)
        => Amount = amount;
}
