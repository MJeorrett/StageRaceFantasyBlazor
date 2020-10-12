using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.Riders.Commands.Create
{
    public class CreateRiderCommandValidator : AbstractValidator<CreateRiderCommand>
    {
        public CreateRiderCommandValidator()
        {
            RuleFor(x => x.FirstName).RiderNameRules();
            RuleFor(x => x.LastName).RiderNameRules();
        }
    }
}
