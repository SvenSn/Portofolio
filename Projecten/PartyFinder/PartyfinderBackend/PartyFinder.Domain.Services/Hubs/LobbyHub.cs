using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PartyFinder.Domain.Services.Interfaces;

[Authorize]
public class LobbyHub(IMemberService memberService) : Hub
{
    private string? UserId => Context.User?.FindFirst("sub")?.Value;

    private async Task<string> GetUserId()
    {
        if (string.IsNullOrEmpty(UserId))
            throw new HubException("User not authenticated");

        var member = await memberService.GetMemberByIdentityserverIdAsync(UserId);
        if (member == null)
            throw new HubException("Member not found");

        return UserId;
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"[LobbyHub] Connected: {Context.UserIdentifier}");
        return base.OnConnectedAsync();
    }

    public async Task JoinLobby(Guid lobbyId)
    {
        await GetUserId();
        await Groups.AddToGroupAsync(Context.ConnectionId, $"Lobby_{lobbyId}");
        Console.WriteLine($"[LobbyHub] {Context.ConnectionId} joined Lobby_{lobbyId}");
    }

    public async Task SendMessage(Guid lobbyId, string message)
    {
        var userId = await GetUserId();
        var member = await memberService.GetMemberByIdentityserverIdAsync(userId);
        Console.WriteLine(
            $"[LobbyHub] SendMessage called by {member.Username} for lobby {lobbyId} at {DateTime.UtcNow}"
        );
        await Clients
            .Group($"Lobby_{lobbyId}")
            .SendAsync(
                "ReceiveMessage",
                new
                {
                    LobbyId = lobbyId,
                    MemberId = member!.id,
                    member.Username,
                    Message = message,
                    Timestamp = DateTime.UtcNow,
                }
            );
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"[LobbyHub] Disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }
}
