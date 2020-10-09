using FluentValidation;

namespace StageRaceFantasy.Application.FantasyTeams.Commands.Create
{
    public class CreateFantasyTeamCommandValidator : AbstractValidator<CreateFantasyTeamCommand>
    {
        public CreateFantasyTeamCommandValidator()
        {
            RuleFor(ft => ft.Name)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
