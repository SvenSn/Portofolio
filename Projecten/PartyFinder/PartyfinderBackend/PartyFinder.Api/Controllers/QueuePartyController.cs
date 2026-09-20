using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyFinder.Api.Contracts;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Domain.Services.Interfaces;

namespace PartyFinder.Api.Controllers;

[Authorize]
[Route("api/queueparty")]
[ApiController]
public class QueuePartyController(IQuePartyService quePartyService) : ControllerBase
{
    [Authorize(Policy = "UserOrAdminPartyFinderReadWritePolicy")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetQueuePartyById([FromRoute] Guid id)
    {
        var result = await quePartyService.GetQueuePartyByIdAsync(id);

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
    [HttpPost]
    public async Task<IActionResult> CreateQueueParty(QueuePartyRequestContract partyToMake)
    {
        var result = quePartyService.CreateQueuePartyAsync(partyToMake);

        return CreatedAtAction(nameof(GetQueuePartyById), new { id = result.Id }, result);
    }

    [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAllQueueParties()
    {
        var result = await quePartyService.GetAllQueuePartiesAsync();

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    [Authorize(Policy = "UserOrAdminPartyFinderReadWritePolicy")]
    [HttpPost("join/{id}")]
    public async Task<IActionResult> JoinQueue([FromRoute] Guid id)
    {
        var result = await quePartyService.JoinQueueAsync(id);

        return Ok(result);
    }

    [Authorize(Policy = "UserOrAdminPartyFinderReadWritePolicy")]
    [HttpDelete("leave/{id}")]
    public async Task<IActionResult> LeaveQueue([FromRoute] Guid id)
    {
        await quePartyService.LeaveQueueAsync(id);

        return NoContent();
    }
}
