using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BudgetApp.Infrastructure.Data;

public static class DatabaseInitializer
{
    public static void Initialize(BudgetDbContext context)
    {
        context.Database.EnsureCreated();
        context.Database.OpenConnection();
        try
        {
            using var transaction = context.Database.BeginTransaction();
            // Fixed internal table names only; legacy data stays unassigned.
            foreach (var table in new[] { "SavingsGoals", "Incomes", "Budgets" })
            {
                using var command = context.Database.GetDbConnection().CreateCommand();
                command.Transaction = transaction.GetDbTransaction();
                command.CommandText = $"PRAGMA table_info('{table}')";
                bool hasAccountId = false;
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                        if (reader.GetString(1) == "AccountId") hasAccountId = true;
                if (!hasAccountId)
                {
                    command.CommandText = $"ALTER TABLE \"{table}\" ADD COLUMN \"AccountId\" INTEGER NULL REFERENCES \"Accounts\" (\"Id\") ON DELETE RESTRICT;";
                    command.ExecuteNonQuery();
                }
                command.CommandText = $"CREATE INDEX IF NOT EXISTS \"IX_{table}_AccountId\" ON \"{table}\" (\"AccountId\");";
                command.ExecuteNonQuery();
            }
            transaction.Commit();
        }
        finally { context.Database.CloseConnection(); }
    }
}
