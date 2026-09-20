using System;
using PartyFinder.Api.Contracts;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;
using PartyFinder.Persistence.Entities;

namespace PartyFinder.Domain.Services.Mapping;

public static class PreLobbyMappingExtensions
{
    public static PreLobby AsEntity(this PreLobbyRequestContract contract)
    {
        return new PreLobby { Boss = contract.Boss.ToString(), TargetSize = contract.TargetSize };
    }

    public static PreLobbyResponseContract AsContract(this PreLobby entity)
    {
        return new PreLobbyResponseContract
        {
            Id = entity.Id,
            LeaderId = entity.LeaderId.ToString(),
            Boss = entity.Boss,
            PreLobbyState = entity.PreLobbyState.ToString(),
            InviteToken = entity.InviteToken,
            CreatedAt = entity.CreatedAt,
            TargetSize = entity.TargetSize,
            MaxSize = entity.MaxSize,
            Members = entity.Members.Select(m => m.AsContract()).ToList(),
        };
    }
}
