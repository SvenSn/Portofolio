using System;
using System.Text.Json.Serialization;

namespace PartyFinder.Api.Contracts.RequestContracts;

public class PreLobbyRequestContract
{
    public string IdentityServerId { get; set; } = null!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BossType Boss { get; set; }
    public int TargetSize { get; set; }
}
