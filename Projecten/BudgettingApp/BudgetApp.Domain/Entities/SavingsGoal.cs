namespace BudgetApp.Domain.Entities;

public class SavingsGoal
{
    public int Id { get; private set; }
    // Null only for goals created before account ownership was introduced.
    public int? AccountId { get; private set; }
    public void AssignToAccount(int accountId)
    {
        if (accountId <= 0) throw new ArgumentOutOfRangeException(nameof(accountId));
        AccountId = accountId;
    }

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

    public decimal TargetAmount
    {
        get;
        private set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Doelbedrag moet groter zijn dan 0.");

            if (value != decimal.Round(value, 2, MidpointRounding.ToEven))
                throw new ArgumentException(
                    "Bedrag mag maximaal twee decimalen bevatten.",
                    nameof(value));

            field = value;
        }
    }

    public decimal CurrentAmount
    {
        get;
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Huidig bedrag mag niet negatief zijn.");

            if (value != decimal.Round(value, 2, MidpointRounding.ToEven))
                throw new ArgumentException(
                    "Bedrag mag maximaal twee decimalen bevatten.",
                    nameof(value));

            field = value;
        }
    }

    public DateTime TargetDate { get; private set; }

    public bool IsCompleted =>
        TargetAmount > 0 && CurrentAmount >= TargetAmount;

    private SavingsGoal()
    {
        // Voor EF Core
    }

    public SavingsGoal(
        string name,
        decimal targetAmount,
        decimal currentAmount,
        DateTime targetDate)
    {
        Name = name;
        TargetAmount = targetAmount;
        CurrentAmount = currentAmount;
        TargetDate = targetDate;
    }

    public void UpdateName(string name)
        => Name = name;

    public void UpdateTargetAmount(decimal targetAmount)
        => TargetAmount = targetAmount;

    public void UpdateTargetDate(DateTime targetDate)
        => TargetDate = targetDate;

    public void AddAmount(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                "Bedrag moet groter zijn dan 0.");



        CurrentAmount += amount;
    }
}
