using BudgetApp.Domain.Enums;

namespace BudgetApp.Domain.Entities;

public class Transaction
{
    public int Id { get; private set; }

    public decimal Amount
    {
        get;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Bedrag moet groter zijn dan 0.");

            field = value;
        }
    }

    public DateTime Date { get; private set; }

    public string Description
    {
        get;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(
                    "Beschrijving is verplicht.",
                    nameof(value));

            field = value;
        }
    } = string.Empty;

    public TransactionType Type { get; private set; }

    public CategoryType Category { get; private set; }

    public int AccountId
    {
        get;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "AccountId moet groter zijn dan 0.");

            field = value;
        }
    }

    private Transaction()
    {
        // Voor EF Core
    }

    public Transaction(
        decimal amount,
        DateTime date,
        string description,
        TransactionType type,
        CategoryType category,
        int accountId)
    {
        Amount = amount;
        Date = date;
        Description = description;
        Type = type;
        Category = category;
        AccountId = accountId;
    }

    public void UpdateAmount(decimal amount)
        => Amount = amount;

    public void UpdateDate(DateTime date)
        => Date = date;

    public void UpdateType(TransactionType type)
    => Type = type;


    public void UpdateDescription(string description)
        => Description = description;

    public void UpdateCategory(CategoryType category)
        => Category = category;
}