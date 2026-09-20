using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PartyFinder.Identityserver.Contracts;
using PartyFinder.Identityserver.Services.Interfaces;

namespace PartyFinder.Identityserver.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PlayerRequestContract request)
        {
            var result = await userService.CreatePlayer(request);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [Authorize(Policy = "AdminPartyFinderReadWritePolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            await userService.RemovePlayer(id);
            return Ok();
        }
    }
}
