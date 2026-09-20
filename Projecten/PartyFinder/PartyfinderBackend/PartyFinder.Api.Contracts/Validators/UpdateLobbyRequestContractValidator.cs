using System;
using FluentValidation;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class UpdateLobbyRequestContractValidator : AbstractValidator<UpdateLobbyRequestContract>
{
    public UpdateLobbyRequestContractValidator()
    {
        RuleFor(l => l.Id)
            .NotEmpty()
            .Must(id => id != Guid.Empty)
            .WithMessage("Must be a valid Guid for LobbyId");
        RuleFor(l => l.Boss)
            .Must(value => Enum.IsDefined(typeof(BossType), value))
            .WithMessage("Invalid Boss type.");
        //geen rule voor boolean nodig
    }
}
