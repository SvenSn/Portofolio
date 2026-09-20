using System;
using FluentValidation;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class QueuePartyRequestContractValidator : AbstractValidator<QueuePartyRequestContract>
{
    public QueuePartyRequestContractValidator()
    {
        RuleFor(qp => qp.Boss)
            .Must(value => Enum.IsDefined(typeof(BossType), value))
            .WithMessage("Invalid Boss type.");
        RuleFor(qp => qp.MemberIds)
            .NotEmpty()
            .ForEach(idRule =>
                idRule
                    .Must(id => id != Guid.Empty)
                    .WithMessage("Each MemberId must be a valid GUID (not Guid.Empty).")
            );
        RuleFor(qp => qp.TargetSize)
            .NotEmpty()
            .GreaterThan(1)
            .LessThanOrEqualTo(5)
            .WithMessage("Miminum duo or maximum 5 man targetsize");
    }
}
