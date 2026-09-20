using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyFinder.Api.Contracts;
using PartyFinder.Api.Contracts.RequestContracts;
using PartyFinder.Domain.Services.Interfaces;

namespace PartyFinder.Api.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class MemberController(IMemberService service, IBlobStorageService blobStorageService)
        : ControllerBase
    {
        [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById([FromRoute] Guid id)
        {
            var result = await service.GetMemberByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] MemberRequestContract MemberToMake)
        {
            var result = await service.CreateMemberAsync(MemberToMake);

            return CreatedAtAction(nameof(GetMemberById), new { id = result.id }, result);
        }

        [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
        [HttpGet("isid/{id}")]
        public async Task<IActionResult> GetMemberByIdentityserverId([FromRoute] string id)
        {
            var result = await service.GetMemberByIdentityserverIdAsync(id);

            return Ok(result);
        }

        [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMember([FromRoute] Guid id)
        {
            await service.RemoveMemberAsync(id);

            return NoContent();
        }

        [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMembers()
        {
            var result = await service.GetAllMembersAsync();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
        [HttpGet("csv")]
        public async Task<IActionResult> GenerateCSVFile()
        {
            var members = await service.GetAllMembersAsync();

            return new FileCallbackResult(
                "text/csv",
                async (responseStream, _) =>
                {
                    // Write CSV to a MemoryStream first
                    using var memoryStream = new MemoryStream();
                    await using (
                        var writer = new StreamWriter(memoryStream, Encoding.UTF8, leaveOpen: true)
                    )
                    {
                        await writer.WriteLineAsync("Id,Name,Email");
                        foreach (var m in members)
                        {
                            await writer.WriteLineAsync(
                                $"{m.id},{m.Username},{m.AccountType},{m.IdentityserverId}"
                            );
                        }
                        await writer.FlushAsync();
                    }
                    memoryStream.Position = 0;

                    // Upload to Blob Storage
                    await blobStorageService.UploadCsvAsync(
                        "membercsvfiles",
                        "members.csv",
                        memoryStream
                    );

                    // Copy to response stream
                    memoryStream.Position = 0;
                    await memoryStream.CopyToAsync(responseStream);
                }
            )
            {
                FileDownloadName = "members.csv",
            };
        }
    }
}
