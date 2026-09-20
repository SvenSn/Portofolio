using BudgetApp.Domain.Enums;

namespace BudgetApp.Domain.Entities;

public class Account
{
    public int Id { get; private set; }

    public string Name
    {
        get;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(
                    "Naam is verplicht.",
                    nameof(value));

            field = value;
        }
    } = string.Empty;

    public AccountType Type { get; private set; }

    public decimal Balance { get; private set; }

    private Account()
    {
        // Voor EF Core
    }

    public Account(string name, AccountType type, decimal balance)
    {
        Name = name;
        Type = type;
        Balance = balance;
    }

    public void UpdateName(string name)
        => Name = name;

    public void ApplyTransaction(decimal amount, TransactionType type)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                "Bedrag moet groter zijn dan 0.");

        Balance += type == TransactionType.Expense
            ? -amount
            : amount;
    }
}