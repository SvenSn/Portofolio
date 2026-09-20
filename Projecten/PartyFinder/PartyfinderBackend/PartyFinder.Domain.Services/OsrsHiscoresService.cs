using System;
using PartyFinder.Domain.Services.Interfaces;

namespace PartyFinder.Domain.Services;

public class OsrsHiscoresService : IOsrsHiScoresService
{
    private readonly HttpClient _httpClient;

    public OsrsHiscoresService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://secure.runescape.com/");
    }

    public async Task<string?> GetAccountTypeAsync(string username)
    {
        // Check normal account (different URL format)
        var normalUrl = $"m=hiscore_oldschool/index_lite.ws?player={username}";
        var response = await _httpClient.GetAsync(normalUrl);

        if (response.IsSuccessStatusCode)
        {
            return "normal";
        }

        // Check ironman types
        var ironmanTypes = new[] { "ironman", "hardcore_ironman", "ultimate" };

        foreach (var type in ironmanTypes)
        {
            var url = $"m=hiscore_oldschool_{type}/index_lite.ws?player={username}";

            response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return type;
            }
        }

        return null; // Player not found
    }
}
