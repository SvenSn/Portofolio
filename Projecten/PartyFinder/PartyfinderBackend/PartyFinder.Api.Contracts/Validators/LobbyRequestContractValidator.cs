using System;
using FluentValidation;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class LobbyRequestContractValidator : AbstractValidator<LobbyRequestContract>
{
    public LobbyRequestContractValidator()
    {
        RuleFor(l => l.Boss)
            .Must(value => Enum.IsDefined(typeof(BossType), value))
            .WithMessage("Invalid Boss type.");
        RuleFor(l => l.MemberIds)
            .NotEmpty()
            .ForEach(idRule =>
                idRule
                    .Must(id => id != Guid.Empty)
                    .WithMessage("Each MemberId must be a valid GUID (not Guid.Empty).")
            );
    }
}
