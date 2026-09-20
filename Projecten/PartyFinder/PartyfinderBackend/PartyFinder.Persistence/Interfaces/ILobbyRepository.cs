using System;
using PartyFinder.Persistence.Entities;

namespace PartyFinder.Persistence.Interfaces;

public interface ILobbyRepository
{
    Task<Lobby> CreateLobbyAsync(Lobby lobby);

    Task<Lobby?> GetLobbyByIdAsync(Guid id);

    Task<List<Lobby>?> GetAllLobbiesAsync();

    Task UpdateLobbyAsync(Lobby lobby);

    Task RemoveLobbyAsync(Lobby lobby);
}
