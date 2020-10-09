using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Update
{
    public class UpdateRiderRaceEntryCommandValidator : AbstractValidator<UpdateRiderRaceEntryCommand>
    {
        public UpdateRiderRaceEntryCommandValidator()
        {
            RuleFor(x => x.BibNumber).RiderRaceEntryBibNumberRules();
            RuleFor(x => x.StarValue).RiderRaceEntryStarValueRules();
        }
    }
}
