using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.RaceStages.Commands.Update
{
    public class UpdateRaceStageCommandValidator : AbstractValidator<UpdateRaceStageCommand>
    {
        public UpdateRaceStageCommandValidator()
        {
            RuleFor(x => x.StartLocation).RaceStageLocationRules();
            RuleFor(x => x.FinishLocation).RaceStageLocationRules();
        }
    }
}
