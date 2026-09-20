using System;
using PartyFinder.Persistence.Entities;

namespace PartyFinder.Persistence.Interfaces;

public interface IPreLobbyRepository
{
    Task<PreLobby> CreatePreLobbyAsync(PreLobby preLobby);

    Task<PreLobby?> GetPreLobbyById(Guid id);

    Task<PreLobby?> GetPreLobbyByIdentityServerId(string id);

    Task<PreLobby?> GetPreLobbyByMemberId(Guid id);

    Task<List<PreLobby>?> GetAllPreLobbiesAsync();

    Task<PreLobby> UpdateProLobbyAsync(PreLobby preLobby);

    Task RemovePreLobbyAsync(PreLobby preLobby);
}
