using System.ComponentModel.DataAnnotations;

namespace PartyFinder.Identityserver.Contracts;

public class PlayerResponseContract
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    [MaxLength(16)]
    public string UserName { get; set; }
}
