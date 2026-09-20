using System;
using FluentValidation;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class PreLobbyRequestContractValidator : AbstractValidator<PreLobbyRequestContract>
{
    public PreLobbyRequestContractValidator()
    {
        RuleFor(pl => pl.Boss)
            .Must(value => Enum.IsDefined(typeof(BossType), value))
            .WithMessage("Invalid Boss type.");
        RuleFor(pl => pl.IdentityServerId)
            .Must(identityServerId => Guid.TryParse(identityServerId, out _))
            .NotEmpty();

        RuleFor(pl => pl.TargetSize).GreaterThan(1).LessThan(6).NotEmpty();
    }
}
