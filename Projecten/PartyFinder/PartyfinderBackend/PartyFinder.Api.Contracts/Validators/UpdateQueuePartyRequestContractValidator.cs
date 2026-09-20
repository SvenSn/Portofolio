using System;
using System.Data.Common;
using FluentValidation;
using PartyFinder.Api.Contracts.RequestContracts;

namespace PartyFinder.Api.Contracts.Validators;

public class UpdateQueuePartyRequestContractValidator
    : AbstractValidator<UpdateQueuePartyRequestContract>
{
    public UpdateQueuePartyRequestContractValidator()
    {
        RuleFor(qp => qp.Id).NotEmpty().WithMessage("Give in a valid queueparty id ");
        RuleFor(pl => pl.Boss)
            .Must(value => Enum.IsDefined(typeof(BossType), value))
            .WithMessage("Invalid Boss type.");
        RuleFor(qp => qp.TargetSize)
            .NotEmpty()
            .GreaterThan(1)
            .LessThanOrEqualTo(5)
            .WithMessage("Miminum duo or maximum 5 man targetsize");
    }
}
