using FluentValidation;

namespace StageRaceFantasy.Application.ValidationRules
{
    public static class RiderRaceEntryRules
    {
        private const int MaxBibNumber = 1000;
        private const int MaxStarValue = 1000;

        public static void RiderRaceEntryBibNumberRules<T>(this IRuleBuilder<T, int> rule)
        {
            rule
                .LessThanOrEqualTo(MaxBibNumber);
        }
        public static void RiderRaceEntryStarValueRules<T>(this IRuleBuilder<T, int> rule)
        {
            rule
                .LessThanOrEqualTo(MaxStarValue);
        }
    }
}
