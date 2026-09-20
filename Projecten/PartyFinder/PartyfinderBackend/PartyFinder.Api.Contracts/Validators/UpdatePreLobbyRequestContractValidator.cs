using System;
using FluentValidation;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class UpdatePreLobbyRequestContractValidator
    : AbstractValidator<UpdatePreLobbyRequestContract>
{
    public UpdatePreLobbyRequestContractValidator()
    {
        RuleFor(pl => pl.Boss)
            .Must(value => Enum.IsDefined(typeof(BossType), value))
            .WithMessage("Invalid Boss type.");
        RuleFor(pl => pl.LeaderId)
            .Must(id => id != Guid.Empty)
            .WithMessage("Give a valid memberid guid in as leaderid");
        RuleFor(pl => pl.Id)
            .Must(id => id != Guid.Empty)
            .NotEmpty()
            .WithMessage("Give a valid prelobby id in.");
    }
}
