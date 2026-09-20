using System;
using Microsoft.AspNetCore.SignalR;

namespace PartyFinder.Domain.Services.Hubs;

public class SubUserIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        return connection.User?.FindFirst("sub")?.Value;
    }
}
