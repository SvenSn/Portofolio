using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PartyFinder.Domain.Services.Interfaces;
using PartyFinder.Domain.Services.Mapping;
using PartyFinder.Persistence;
using PartyFinder.Persistence.Interfaces;
using PartyFinder.Persistence.Repositories;

namespace PartyFinder.Domain.Services.Hubs;

[Authorize]
public class PreLobbyHub(
    IPreLobbyService service,
    IQuePartyService quePartyService,
    IMemberRepository memberRepo,
    IUnitOfWork uow,
    IQueuePartyRepository queuePartyRepo
) : Hub
{
    private string? UserId => Context.User?.FindFirst("sub")?.Value;

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"[PreLobbyHub] Connection established: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public async Task Join(Guid preLobbyId)
    {
        var userId = UserId ?? throw new HubException("User not authenticated");
        await service.JoinPreLobbyAsync(userId, preLobbyId);
        await Groups.AddToGroupAsync(Context.ConnectionId, preLobbyId.ToString());

        var updatedLobby = await service.GetPreLobbyById(preLobbyId);
        await Clients.Group(preLobbyId.ToString()).SendAsync("PreLobbyUpdated", updatedLobby);
    }

    public async Task Leave(Guid preLobbyId)
    {
        var userId = UserId ?? throw new HubException("User not authenticated");
        await service.LeavePreLobbyAsync(userId, preLobbyId);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, preLobbyId.ToString());

        var updatedLobby = await service.GetPreLobbyById(preLobbyId);
        if (updatedLobby != null)
        {
            await Clients.Group(preLobbyId.ToString()).SendAsync("PreLobbyUpdated", updatedLobby);
        }
    }

    public async Task Disband(Guid preLobbyId)
    {
        var userId = UserId ?? throw new HubException("User not authenticated");
        await service.RemovePreLobbyAsync(preLobbyId);

        await Clients.Group(preLobbyId.ToString()).SendAsync("PreLobbyDisbanded", preLobbyId);
    }

    public async Task JoinQueue(Guid preLobbyId)
    {
        try
        {
            var queueParty = await quePartyService.JoinQueueAsync(preLobbyId);
            await Clients.Group(preLobbyId.ToString()).SendAsync("QueueJoined", queueParty);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PreLobbyHub] JoinQueue error: {ex.Message}");
            throw new HubException($"Failed to invoke 'JoinQueue': {ex.Message}");
        }
    }

    public async Task LeaveQueue(Guid queuePartyId)
    {
        var queueParty = await queuePartyRepo.GetQueuePartyByIdAsync(queuePartyId);
        if (queueParty == null)
            return;

        var member = queueParty.Members?.FirstOrDefault();
        if (member?.PreLobbyId == null)
            return;

        var preLobbyId = member.PreLobbyId.Value;

        await quePartyService.LeaveQueueAsync(queuePartyId);

        await Clients
            .Group(preLobbyId.ToString())
            .SendAsync("QueueLeft", new { QueuePartyId = queuePartyId });
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        // UserId will be null on disconnect, so check first
        if (!string.IsNullOrEmpty(UserId))
        {
            var member = await memberRepo.GetMemberByIdentityserverIdAsync(UserId);
            if (member != null)
                await service.HandleMemberTimeoutAsync(member.Id);
        }

        await base.OnDisconnectedAsync(exception);
    }
}
