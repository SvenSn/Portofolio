using System;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;
using PartyFinder.Domain.Services.Interfaces;
using PartyFinder.Domain.Services.Mapping;
using PartyFinder.Persistence.Interfaces;
using PartyFinder.Persistence.Repositories;

namespace PartyFinder.Domain.Services;

public class LobbyService(ILobbyRepository repo, IUnitOfWork uow, IMemberRepository memberRepo)
    : ILobbyService
{
    public async Task<LobbyResponseContract> CreateLobbyAsync(LobbyRequestContract lobby)
    {
        var entity = lobby.AsEntity();

        var members = new List<Member>();

        foreach (var memberid in lobby.MemberIds)
        {
            var member = await memberRepo.GetMemberByIdAsync(memberid);
            if (member != null)
            {
                members.Add(member);
            }
        }

        entity.Members = members;

        await repo.CreateLobbyAsync(entity);
        await uow.SaveChangesAsync();

        return entity.AsContract();
    }

    public async Task<List<LobbyResponseContract>?> GetAllLobbiesAsync()
    {
        var result = await repo.GetAllLobbiesAsync();

        return result?.Select(l => l.AsContract()).ToList();
    }

    public async Task<LobbyResponseContract?> GetLobbyByIdAsync(Guid id)
    {
        var lobby = await repo.GetLobbyByIdAsync(id);

        return lobby?.AsContract();
    }

    public async Task RemoveLobbyAsync(Guid id)
    {
        var lobby = await repo.GetLobbyByIdAsync(id);

        if (lobby is null)
            return;

        await repo.RemoveLobbyAsync(lobby);
        await uow.SaveChangesAsync();
    }

    public async Task<LobbyResponseContract?> UpdateLobbyAsync(
        UpdateLobbyRequestContract lobbyToUpdate
    )
    {
        var lobby = await repo.GetLobbyByIdAsync(lobbyToUpdate.Id);

        if (lobby is null)
            return null;

        if (string.IsNullOrEmpty(lobbyToUpdate.Boss))
        {
            lobby.Boss = lobbyToUpdate.Boss;
        }
        if (lobbyToUpdate.IsActive.HasValue)
        {
            lobby.IsActive = lobbyToUpdate.IsActive.Value;
        }

        await uow.SaveChangesAsync();

        return lobby.AsContract();
    }
}
