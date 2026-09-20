using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PartyFinder.Identityserver.Contracts;

public class PlayerRequestContract
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(16)]
    [MinLength(3)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
