using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Domain.Services.Interfaces;

namespace PartyFinder.Api.Controllers;

[Authorize]
[Route("api/prelobbies")]
[ApiController]
public class PreLobbyController(IPreLobbyService service) : ControllerBase
{
    [Authorize(Policy = "UserOrAdminPartyFinderReadWritePolicy")]
    [HttpPost]
    public async Task<IActionResult> CreatePrelobby(PreLobbyRequestContract contract)
    {
        var result = await service.CreatePreLobbyAsync(contract);

        return CreatedAtAction(nameof(GetPreLobbyById), new { id = result.Id }, result);
    }

    [Authorize(Policy = "UserOrAdminPartyFinderReadWritePolicy")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPreLobbyById([FromRoute] Guid id)
    {
        var result = await service.GetPreLobbyById(id);

        return Ok(result);
    }

    [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAllPreLobbies()
    {
        var result = await service.GetAllPreLobbiesAsync();

        return Ok(result);
    }

    [Authorize(Policy = "UserOrAdminPartyFinderReadWritePolicy")]
    [HttpGet("user/{identityServerUserId}")]
    public async Task<IActionResult> GetByUser([FromRoute] string identityServerUserId)
    {
        var result = await service.GetPreLobbyByIdentityServerId(identityServerUserId);

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    [Authorize(Policy = "UserOrAdminPartyFinderReadWritePolicy")]
    [HttpPatch]
    public async Task<ActionResult> UpdatePreLobby(
        [FromBody] UpdatePreLobbyRequestContract contract
    )
    {
        var result = await service.UpdatePreLobbyAsync(contract);

        return Ok(result);
    }

    [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePreLobby([FromRoute] Guid id)
    {
        await service.RemovePreLobbyAsync(id);
        return NoContent();
    }
}
