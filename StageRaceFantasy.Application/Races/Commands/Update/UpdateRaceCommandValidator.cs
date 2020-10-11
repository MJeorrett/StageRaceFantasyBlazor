using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.Races.Commands.Update
{
    public class UpdateRaceCommandValidator : AbstractValidator<UpdateRaceCommand>
    {
        public UpdateRaceCommandValidator()
        {
            RuleFor(x => x.Name).RaceNameRules();
        }
    }
}
