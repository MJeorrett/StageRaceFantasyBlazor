using FluentValidation;

namespace StageRaceFantasy.Application.ValidationRules
{
    public static class RaceStageRules
    {
        private const int LocationMaxLength = 200;

        public static void RaceStageLocationRules<T>(this IRuleBuilder<T, string> rule)
        {
            rule
                .NotEmpty()
                .MaximumLength(LocationMaxLength);
        }
    }
}
