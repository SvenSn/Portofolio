using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class MemberRequestContractValidator : AbstractValidator<MemberRequestContract>
{
    public MemberRequestContractValidator()
    {
        RuleFor(m => m.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(16)
            .WithMessage("Username must be 3 characters long and max 16 characters long.");
        RuleFor(m => m.IdentityServerId)
            .NotEmpty()
            .Must(identityServerId => Guid.TryParse(identityServerId, out _))
            .WithMessage("Must be a valid identityserver guid");
    }
}
