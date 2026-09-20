using System;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;

namespace PartyFinder.Domain.Services.Interfaces;

public interface IQuePartyService
{
    Task<QueuePartyResponseContract> CreateQueuePartyAsync(QueuePartyRequestContract queueParty);

    Task<QueuePartyResponseContract?> GetQueuePartyByIdAsync(Guid id);

    Task<List<QueuePartyResponseContract>?> GetAllQueuePartiesAsync();

    Task<QueuePartyResponseContract> JoinQueueAsync(Guid prelobbyId);

    Task LeaveQueueAsync(Guid queuePartyId);

    Task<QueuePartyResponseContract?> UpdateQueuePartyAsync(
        UpdateQueuePartyRequestContract partyToUpdate
    );

    Task RemoveQueuePartyAsync(Guid id);
}
