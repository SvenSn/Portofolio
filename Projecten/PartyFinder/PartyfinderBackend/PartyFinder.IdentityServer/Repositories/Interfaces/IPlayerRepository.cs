using System;
using PartyFinder.Identityserver.Models;

namespace PartyFinder.Identityserver.Repositories.Interfaces;

public interface IPlayerRepository
{
    Task<ApplicationUser> CreatePlayer(ApplicationUser player, string password);

    Task DeletePlayer(string identityServerId);
}
