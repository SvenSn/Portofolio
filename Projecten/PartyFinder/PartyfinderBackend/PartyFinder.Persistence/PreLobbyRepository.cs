using System;
using Microsoft.EntityFrameworkCore;
using PartyFinder.Persistence.Entities;
using PartyFinder.Persistence.Interfaces;

namespace PartyFinder.Persistence;

public class PreLobbyRepository(PartyFinderDBContext context) : IPreLobbyRepository
{
    public async Task<PreLobby> CreatePreLobbyAsync(PreLobby preLobby)
    {
        await context.PreLobbies.AddAsync(preLobby);

        return preLobby;
    }

    public async Task<List<PreLobby>?> GetAllPreLobbiesAsync()
    {
        return await context.PreLobbies.ToListAsync();
    }

    public async Task<PreLobby?> GetPreLobbyById(Guid id)
    {
        var prelobby = await context
            .PreLobbies.Include(pl => pl.Members)
            .FirstOrDefaultAsync(pl => pl.Id == id);

        return prelobby;
    }

    public async Task<PreLobby?> GetPreLobbyByIdentityServerId(string id)
    {
        var preLobby = await context
            .PreLobbies.Include(pl => pl.Members)
            .FirstOrDefaultAsync(pl => pl.Members.Any(m => m.IdentityServerId == id));
        if (preLobby == null)
            return null;

        return preLobby;
    }

    public async Task<PreLobby?> GetPreLobbyByMemberId(Guid id)
    {
        var preLobby = await context
            .PreLobbies.Include(pl => pl.Members)
            .FirstOrDefaultAsync(pl => pl.Members.Any(m => m.Id == id));

        if (preLobby == null)
            throw new ArgumentNullException(
                $"Prelobby with member with id : {id} cannot be found."
            );

        return preLobby;
    }

    public Task RemovePreLobbyAsync(PreLobby preLobby)
    {
        context.PreLobbies.Remove(preLobby);

        return Task.FromResult(preLobby);
    }

    public Task<PreLobby> UpdateProLobbyAsync(PreLobby preLobby)
    {
        context.PreLobbies.Update(preLobby);

        return Task.FromResult(preLobby);
    }
}
