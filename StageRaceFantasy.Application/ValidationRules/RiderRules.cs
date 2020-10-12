using FluentValidation;

namespace StageRaceFantasy.Application.ValidationRules
{
    public static class RiderRules
    {
        public const int NameMaxLength = 200;

        public static void RiderNameRules<T>(this IRuleBuilder<T, string> rule)
        {
            rule.NotEmpty().MaximumLength(NameMaxLength);
        }
    }
}
