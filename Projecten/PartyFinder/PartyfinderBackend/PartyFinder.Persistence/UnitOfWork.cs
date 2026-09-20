using System;
using Microsoft.EntityFrameworkCore.Storage;
using PartyFinder.Persistence.Entities;
using PartyFinder.Persistence.Repositories;

namespace PartyFinder.Persistence;

public class UnitOfWork(PartyFinderDBContext context) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;

    public async Task<IDisposable> BeginTransactionAsync(CancellationToken ct = default)
    {
        _transaction = await context.Database.BeginTransactionAsync(ct);
        return _transaction;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return context.SaveChangesAsync(ct);
    }

    public Task CommitAsync(CancellationToken ct = default)
    {
        return _transaction?.CommitAsync(ct) ?? Task.CompletedTask;
    }
}
