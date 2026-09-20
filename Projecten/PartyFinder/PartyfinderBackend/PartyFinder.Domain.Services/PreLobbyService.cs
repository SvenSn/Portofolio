using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.SignalR;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Api.Contracts.ResponseContracts;
using PartyFinder.Domain.Services.Hubs;
using PartyFinder.Domain.Services.Interfaces;
using PartyFinder.Domain.Services.Mapping;
using PartyFinder.Persistence.Entities;
using PartyFinder.Persistence.Interfaces;
using PartyFinder.Persistence.Repositories;

namespace PartyFinder.Domain.Services;

public class PreLobbyService(
    IPreLobbyRepository preLobbyRepo,
    IMemberRepository memberRepo,
    IUnitOfWork uow,
    IHubContext<PreLobbyHub> hubContext
) : IPreLobbyService
{
    public async Task<PreLobbyResponseContract> CreatePreLobbyAsync(
        PreLobbyRequestContract preLobby
    )
    {
        var member =
            await memberRepo.GetMemberByIdentityserverIdAsync(preLobby.IdentityServerId)
            ?? throw new ArgumentNullException("Member not found");

        var entity = preLobby.AsEntity();
        entity.LeaderId = Guid.Parse(member.IdentityServerId);
        entity.PreLobbyState = PreLobbyState.Open;
        await preLobbyRepo.CreatePreLobbyAsync(entity);
        member.PreLobbyId = entity.Id;
        member.LobbyId = null;
        member.State = MemberState.InPreLobby;

        await uow.SaveChangesAsync();

        return entity.AsContract();
    }

    public async Task<List<PreLobbyResponseContract>?> GetAllPreLobbiesAsync()
    {
        var result = await preLobbyRepo.GetAllPreLobbiesAsync();

        if (result is null)
            return null;

        return result.Select(pl => pl.AsContract()).ToList();
    }

    public async Task<PreLobbyResponseContract?> GetPreLobbyById(Guid id)
    {
        var result = await preLobbyRepo.GetPreLobbyById(id);
        if (result == null)
            return null;

        return result.AsContract();
    }

    public async Task<PreLobbyResponseContract?> GetPreLobbyByIdentityServerId(string id)
    {
        var result = await preLobbyRepo.GetPreLobbyByIdentityServerId(id);

        if (result == null)
            return null;

        return result.AsContract();
    }

    public async Task<PreLobbyResponseContract?> GetPreLobbyByMemberId(Guid id)
    {
        var result = await preLobbyRepo.GetPreLobbyByMemberId(id);

        if (result is null)
            return null;

        return result.AsContract();
    }

    public async Task<PreLobbyResponseContract> JoinPreLobbyAsync(string IdentityServerId, Guid id)
    {
        var preLobby = await preLobbyRepo.GetPreLobbyById(id);
        var member = await memberRepo.GetMemberByIdentityserverIdAsync(IdentityServerId);
        Debug.Write(preLobby);

        if (preLobby.Members.Any(m => m.IdentityServerId == IdentityServerId))
            return preLobby.AsContract(); // Already in lobby
        member.PreLobbyId = preLobby.Id;
        member.State = MemberState.InPreLobby;
        preLobby.Members.Add(member);
        await uow.SaveChangesAsync();

        preLobby = await preLobbyRepo.GetPreLobbyById(id);

        var updated = preLobby.AsContract();

        return updated;
    }

    public async Task RemovePreLobbyAsync(Guid id)
    {
        var prelobby = await preLobbyRepo.GetPreLobbyById(id);

        foreach (var member in prelobby.Members)
        {
            member.PreLobbyId = null;
            member.State = MemberState.Idle;
            prelobby.Members.Remove(member);
        }

        await preLobbyRepo.RemovePreLobbyAsync(prelobby);

        await uow.SaveChangesAsync();
    }

    public async Task<PreLobbyResponseContract?> UpdatePreLobbyAsync(
        UpdatePreLobbyRequestContract updateContract
    )
    {
        var prelobby = await preLobbyRepo.GetPreLobbyById(updateContract.Id);

        if (prelobby is null)
            return null;
        if (updateContract.Boss.HasValue)
            prelobby.Boss = updateContract.Boss.Value.ToString();

        if (updateContract.LeaderId.HasValue)
            prelobby.LeaderId = updateContract.LeaderId.Value;

        await uow.SaveChangesAsync();

        return prelobby.AsContract();
    }

    private async Task PromoteNewLeaderOrDisband(PreLobby lobby)
    {
        if (!lobby.Members.Any())
        {
            await preLobbyRepo.RemovePreLobbyAsync(lobby);
            return;
        }

        var next = lobby.Members.OrderBy(m => m.IdentityServerId).First();

        if (!Guid.TryParse(next.IdentityServerId, out var leaderGuid))
            throw new InvalidOperationException(
                $"Invalid IdentityServerId: {next.IdentityServerId}"
            );

        lobby.LeaderId = leaderGuid;
    }

    public async Task HandleMemberTimeoutAsync(Guid memberId)
    {
        var member = await memberRepo.GetMemberByIdAsync(memberId);
        if (member?.PreLobbyId == null)
            return;

        var lobby = await preLobbyRepo.GetPreLobbyById(member.PreLobbyId.Value);

        lobby.Members.Remove(member);
        member.PreLobbyId = null;
        member.State = MemberState.Idle;

        await PromoteNewLeaderOrDisband(lobby);

        await uow.SaveChangesAsync();
        await hubContext.Clients.Group(lobby.Id.ToString()).SendAsync("PreLobbyUpdated");
    }

    public async Task LeavePreLobbyAsync(string identityServerId, Guid preLobbyId)
    {
        var lobby = await preLobbyRepo.GetPreLobbyById(preLobbyId);
        var member = lobby.Members.FirstOrDefault(m => m.IdentityServerId == identityServerId);
        if (member is null)
            return;

        lobby.Members.Remove(member);
        member.PreLobbyId = null;
        member.State = MemberState.Idle;

        if (!lobby.Members.Any())
        {
            await preLobbyRepo.RemovePreLobbyAsync(lobby);
            await uow.SaveChangesAsync();
            await hubContext
                .Clients.Group(lobby.Id.ToString())
                .SendAsync("PreLobbyDisbanded", lobby.Id);
            return;
        }

        if (lobby.LeaderId.ToString() == identityServerId)
        {
            await PromoteNewLeaderOrDisband(lobby);
        }

        await uow.SaveChangesAsync();

        var updated = (await preLobbyRepo.GetPreLobbyById(preLobbyId)).AsContract();
        await hubContext.Clients.Group(lobby.Id.ToString()).SendAsync("PreLobbyUpdated", updated);
    }
}
