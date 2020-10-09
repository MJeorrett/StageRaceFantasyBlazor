using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.FantasyTeams.Commands.Update
{
    public class UpdateFantasyTeamCommandValidator : AbstractValidator<UpdateFantasyTeamCommand>
    {
        public UpdateFantasyTeamCommandValidator()
        {
            RuleFor(c => c.Name).FantasyTeamNameRules();
        }
    }
}
