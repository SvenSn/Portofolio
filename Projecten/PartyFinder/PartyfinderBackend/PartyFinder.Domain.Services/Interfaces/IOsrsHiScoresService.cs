using System;

namespace PartyFinder.Domain.Services.Interfaces;

public interface IOsrsHiScoresService
{
    Task<string?> GetAccountTypeAsync(string username);
}
