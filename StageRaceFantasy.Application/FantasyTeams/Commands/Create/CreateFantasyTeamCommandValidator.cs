using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.FantasyTeams.Commands.Create
{
    public class CreateFantasyTeamCommandValidator : AbstractValidator<CreateFantasyTeamCommand>
    {
        public CreateFantasyTeamCommandValidator()
        {
            RuleFor(c => c.Name).FantasyTeamName();
        }
    }
}
