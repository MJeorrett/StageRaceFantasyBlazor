using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.RaceStages.Commands.Create
{
    public class CreateRaceStageCommandValidator : AbstractValidator<CreateRaceStageCommand>
    {
        public CreateRaceStageCommandValidator()
        {
            RuleFor(x => x.RaceId).NotEmpty();
            RuleFor(x => x.StartLocation).RaceStageLocationRules();
            RuleFor(x => x.FinishLocation).RaceStageLocationRules();
        }
    }
}
