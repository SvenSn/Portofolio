using System;
using PartyFinder.Api.Contracts;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;

namespace PartyFinder.Domain.Services.Mapping;

public static class QueuePartyMappingExtensions
{
    public static QueuePartyResponseContract AsContract(this QueueParty entity)
    {
        return new QueuePartyResponseContract
        {
            Id = entity.Id,
            Boss = entity.Boss,
            TargetSize = entity.TargetSize,
            CreatedAt = entity.CreatedAt,
            Members = entity.Members.Select(m => m.AsContract()).ToList(),
        };
    }

    public static QueueParty AsEntity(this QueuePartyRequestContract contract)
    {
        return new QueueParty { Boss = contract.Boss, TargetSize = contract.TargetSize };
    }
}
