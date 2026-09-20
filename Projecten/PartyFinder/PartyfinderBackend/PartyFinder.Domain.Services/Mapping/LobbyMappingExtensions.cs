using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;
using PartyFinder.Persistence.Entities;

namespace PartyFinder.Domain.Services.Mapping;

public static class LobbyMappingExtensions
{
    public static LobbyResponseContract AsContract(this Lobby entity)
    {
        return new LobbyResponseContract
        {
            Id = entity.Id,
            Boss = entity.Boss,
            CreatedAt = entity.CreatedAt,
            FinishedAt = entity.FinishedAt,
            IsActive = entity.IsActive,
            Members = entity.Members.Select(m => m.AsContract()).ToList(),
        };
    }

    public static Lobby AsEntity(this LobbyRequestContract contract)
    {
        return new Lobby { Boss = contract.Boss };
    }
}
