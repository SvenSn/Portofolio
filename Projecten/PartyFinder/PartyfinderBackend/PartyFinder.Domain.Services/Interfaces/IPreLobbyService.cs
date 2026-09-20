using System;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;

namespace PartyFinder.Domain.Services.Interfaces;

public interface IPreLobbyService
{
    Task<PreLobbyResponseContract> CreatePreLobbyAsync(PreLobbyRequestContract preLobby);

    Task<PreLobbyResponseContract?> GetPreLobbyById(Guid id);

    Task<PreLobbyResponseContract?> GetPreLobbyByIdentityServerId(string id);
    Task HandleMemberTimeoutAsync(Guid memberId);

    Task LeavePreLobbyAsync(string identityServerId, Guid preLobbyId);
    Task<PreLobbyResponseContract?> GetPreLobbyByMemberId(Guid id);

    Task<List<PreLobbyResponseContract>?> GetAllPreLobbiesAsync();

    Task<PreLobbyResponseContract> JoinPreLobbyAsync(string IdentityServerId, Guid inviteToken);
    Task<PreLobbyResponseContract?> UpdatePreLobbyAsync(
        UpdatePreLobbyRequestContract updateContract
    );

    Task RemovePreLobbyAsync(Guid id);
}
