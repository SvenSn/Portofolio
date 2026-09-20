using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Domain.Services.Interfaces;
using PartyFinder.Persistence.Entities;

namespace PartyFinder.Api.Controllers;

[Authorize]
[Route("api/lobby")]
[ApiController]
public class LobbyController(ILobbyService lobbyService) : ControllerBase
{
    [Authorize(Policy = "UserPartyFinderReadWritePolicy")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLobbyById([FromRoute] Guid id)
    {
        var lobby = await lobbyService.GetLobbyByIdAsync(id);

        if (lobby == null)
            return NoContent();

        return Ok(lobby);
    }

    [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
    [HttpPost]
    public async Task<IActionResult> CreateLobby([FromBody] LobbyRequestContract lobbyToMake)
    {
        var lobby = await lobbyService.CreateLobbyAsync(lobbyToMake);

        if (lobby == null)
            return NotFound();

        return CreatedAtAction(nameof(GetLobbyById), new { id = lobby.Id }, lobby);
    }

    [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAllLobbies()
    {
        var lobbies = await lobbyService.GetAllLobbiesAsync();

        if (lobbies == null)
            return NoContent();

        return Ok(lobbies);
    }

    [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateLobby([FromBody] UpdateLobbyRequestContract updateLobby)
    {
        var lobby = await lobbyService.UpdateLobbyAsync(updateLobby);

        if (lobby == null)
            return NotFound();

        return Ok(lobby);
    }

    [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLobby([FromRoute] Guid id)
    {
        await lobbyService.RemoveLobbyAsync(id);

        return NoContent();
    }
}
