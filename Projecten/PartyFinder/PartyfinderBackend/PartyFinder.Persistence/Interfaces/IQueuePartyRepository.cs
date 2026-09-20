using System;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace PartyFinder.Persistence.Interfaces;

public interface IQueuePartyRepository
{
    Task<QueueParty> CreateQueuePartyAsync(QueueParty queueParty);

    Task<QueueParty?> GetQueuePartyByIdAsync(Guid id);

    Task<List<QueueParty>?> GetAllQueuePartiesAsync();

    Task UpdateQueuePartyAsync(QueueParty queueParty);

    Task RemoveQueuePartyAsync(QueueParty queueParty);
}
