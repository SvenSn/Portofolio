namespace BudgetApp.App.Services;

public sealed class ActiveAccountState
{
    public int Id { get; set; }
    public int RequireId() => Id;
}
