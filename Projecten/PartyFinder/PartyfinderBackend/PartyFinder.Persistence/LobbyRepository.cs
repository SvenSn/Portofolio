using System;
using Microsoft.EntityFrameworkCore;
using PartyFinder.Persistence.Entities;
using PartyFinder.Persistence.Interfaces;

namespace PartyFinder.Persistence;

public class LobbyRepository(PartyFinderDBContext context) : ILobbyRepository
{
    public async Task<Lobby> CreateLobbyAsync(Lobby lobby)
    {
        await context.Lobbies.AddAsync(lobby);

        return lobby;
    }

    public async Task<List<Lobby>?> GetAllLobbiesAsync()
    {
        var result = await context.Lobbies.Include(l => l.Members).ToListAsync();

        return result;
    }

    public async Task<Lobby?> GetLobbyByIdAsync(Guid id)
    {
        var result = await context
            .Lobbies.Include(l => l.Members)
            .FirstOrDefaultAsync(l => l.Id == id);

        return result;
    }

    public Task RemoveLobbyAsync(Lobby lobby)
    {
        context.Lobbies.Remove(lobby);

        return Task.CompletedTask;
    }

    public Task UpdateLobbyAsync(Lobby lobby)
    {
        context.Lobbies.Update(lobby);

        return Task.CompletedTask;
    }
}
