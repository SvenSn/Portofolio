using PartyFinder.Persistence.Entities;

public enum MemberState
{
    Idle,
    InPreLobby,
    InQueueParty,
    InLobby,
}

public class Member
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;
    public string IdentityServerId { get; set; } = null!;
    public MemberState State { get; set; }

    public string AccountType { get; set; }

    //FK+Navigation property
    public Guid? PreLobbyId { get; set; }
    public PreLobby? PreLobby { get; set; }

    //FK+Navigation property
    public Guid? QueuePartyId { get; set; }
    public QueueParty QueueParty { get; set; }

    //FK + navigationproperty
    public Guid? LobbyId { get; set; }
    public Lobby? Lobby { get; set; }
}
