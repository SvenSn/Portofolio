using System;
using Microsoft.EntityFrameworkCore;
using PartyFinder.Persistence.Entities;
using PartyFinder.Persistence.Interfaces;

namespace PartyFinder.Persistence;

public class QueuePartyRepository(PartyFinderDBContext context) : IQueuePartyRepository
{
    public async Task<QueueParty> CreateQueuePartyAsync(QueueParty queueParty)
    {
        var result = await context.QueueParties.AddAsync(queueParty);

        return queueParty;
    }

    public async Task<List<QueueParty>?> GetAllQueuePartiesAsync()
    {
        return await context.QueueParties.Include(q => q.Members).ToListAsync();
    }

    public async Task<QueueParty?> GetQueuePartyByIdAsync(Guid id)
    {
        return await context
            .QueueParties.Include(q => q.Members)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public Task RemoveQueuePartyAsync(QueueParty queueParty)
    {
        context.QueueParties.Remove(queueParty);

        return Task.CompletedTask;
    }

    public Task UpdateQueuePartyAsync(QueueParty queueParty)
    {
        context.QueueParties.Update(queueParty);

        return Task.CompletedTask;
    }
}
