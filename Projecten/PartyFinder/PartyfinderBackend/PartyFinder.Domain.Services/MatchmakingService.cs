using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PartyFinder.Domain.Services.Mapping;
using PartyFinder.Persistence.Entities;
using PartyFinder.Persistence.Interfaces;
using PartyFinder.Persistence.Repositories;

namespace PartyFinder.Domain.Services;

public class MatchmakingService(IServiceScopeFactory scopeFactory, IHubContext<LobbyHub> hubContext)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await RunMatchmakingAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            await Task.Delay(30000, stoppingToken);
        }
    }

    private async Task RunMatchmakingAsync(CancellationToken stoppingToken)
    {
        using var scope = scopeFactory.CreateScope();

        var queueRepo = scope.ServiceProvider.GetRequiredService<IQueuePartyRepository>();
        var lobbyRepo = scope.ServiceProvider.GetRequiredService<ILobbyRepository>();
        var preLobbyRepo = scope.ServiceProvider.GetRequiredService<IPreLobbyRepository>();
        var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        var queueGroups = await queueRepo.GetAllQueuePartiesAsync();
        var grouped = queueGroups.GroupBy(q => (q.Boss, q.TargetSize));

        foreach (var group in grouped)
        {
            var parties = group.OrderByDescending(q => q.Members.Count).ToList();

            while (
                await TryCreateLobbyAsync(
                    parties,
                    group.Key.Boss,
                    group.Key.TargetSize,
                    queueRepo,
                    lobbyRepo,
                    preLobbyRepo,
                    uow,
                    stoppingToken
                )
            ) { }
        }
    }

    private async Task<bool> TryCreateLobbyAsync(
        List<QueueParty> parties,
        string boss,
        int targetSize,
        IQueuePartyRepository queueRepo,
        ILobbyRepository lobbyRepo,
        IPreLobbyRepository preLobbyRepo,
        IUnitOfWork uow,
        CancellationToken stoppingToken
    )
    {
        var ordered = parties.OrderByDescending(p => p.Members.Count).ToList();
        var selected = new List<QueueParty>();
        int remaining = targetSize;

        foreach (var party in ordered)
        {
            if (party.Members.Count <= remaining)
            {
                selected.Add(party);
                remaining -= party.Members.Count;
                if (remaining == 0)
                    break;
            }
        }

        if (remaining != 0)
            return false;

        var lobby = new Lobby
        {
            Boss = boss,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            Members = selected.SelectMany(p => p.Members).ToList(),
        };

        foreach (var party in selected)
        {
            foreach (var member in party.Members)
            {
                member.QueuePartyId = null;
                member.PreLobbyId = null;
                member.LobbyId = lobby.Id;
                member.State = MemberState.InLobby;
            }

            await queueRepo.RemoveQueuePartyAsync(party);
            parties.Remove(party);
        }

        var preLobbyIds = lobby
            .Members.Where(m => m.PreLobbyId != null)
            .Select(m => m.PreLobbyId.Value)
            .Distinct()
            .ToList();

        foreach (var preLobbyId in preLobbyIds)
        {
            var preLobby = await preLobbyRepo.GetPreLobbyById(preLobbyId);
            if (preLobby != null)
                await preLobbyRepo.RemovePreLobbyAsync(preLobby);
        }

        await lobbyRepo.CreateLobbyAsync(lobby);
        lobby.IsActive = true;
        await uow.SaveChangesAsync();

        foreach (var member in lobby.Members)
        {
            Console.WriteLine(member.IdentityServerId);
            await hubContext
                .Clients.User(member.IdentityServerId)
                .SendAsync("MatchFound", lobby.AsContract());
        }

        return true;
    }

    public async Task QueuePreLobbyAsync(Guid preLobbyId, string boss, int targetSize)
    {
        using var scope = scopeFactory.CreateScope();

        var preLobbyRepo = scope.ServiceProvider.GetRequiredService<IPreLobbyRepository>();
        var queueRepo = scope.ServiceProvider.GetRequiredService<IQueuePartyRepository>();
        var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        var preLobby = await preLobbyRepo.GetPreLobbyById(preLobbyId);
        if (preLobby == null)
            throw new Exception("PreLobby not found");

        var queueParty = new QueueParty
        {
            Boss = boss,
            TargetSize = targetSize,
            Members = preLobby.Members.ToList(),
        };

        foreach (var member in preLobby.Members)
        {
            member.QueuePartyId = queueParty.Id;
            member.State = MemberState.InQueueParty;
        }

        await queueRepo.CreateQueuePartyAsync(queueParty);
        await uow.SaveChangesAsync();
    }
}
