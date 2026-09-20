using System;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;

namespace PartyFinder.Domain.Services.Interfaces;

public interface ILobbyService
{
    Task<LobbyResponseContract> CreateLobbyAsync(LobbyRequestContract lobby);

    Task<LobbyResponseContract?> GetLobbyByIdAsync(Guid id);

    Task<List<LobbyResponseContract>?> GetAllLobbiesAsync();

    Task<LobbyResponseContract?> UpdateLobbyAsync(UpdateLobbyRequestContract lobbyToUpdate);

    Task RemoveLobbyAsync(Guid id);
}
