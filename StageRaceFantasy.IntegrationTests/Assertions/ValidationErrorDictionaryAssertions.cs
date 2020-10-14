using FluentAssertions;
using FluentAssertions.Execution;
using System.Collections.Generic;
using System.Linq;

namespace StageRaceFantasy.IntegrationTests.Assertions
{
    public static class ValidationErrorDictionaryExtensions
    {
        public static ValidationErrorDictionaryAssertions Should(this Dictionary<string, string[]> validationErrorDictionary)
        {
            return new ValidationErrorDictionaryAssertions(validationErrorDictionary);
        }
    }

    public class ValidationErrorDictionaryAssertions
    {
        private readonly Dictionary<string, string[]> _subject;

        public ValidationErrorDictionaryAssertions(Dictionary<string, string[]> subject)
        {
            _subject = subject;
        }

        // TODO: Unit test this.
        public AndConstraint<ValidationErrorDictionaryAssertions> ContainPartialErrorForProperty(string propertyName, string partialErrorMessage)
        {
            Execute.Assertion
                .ForCondition(propertyName != null && partialErrorMessage != null)
                .FailWith($"You must provide {nameof(propertyName)} and {nameof(partialErrorMessage)}.")
                .Then
                .ForCondition(_subject.ContainsKey(propertyName))
                .FailWith("Expected there to be an error for key {0}.\nBut didn't find among error keys {1}.", propertyName, _subject.Keys.ToList())
                .Then
                .ForCondition(_subject[propertyName].Any(x => x.Contains(partialErrorMessage)))
                .FailWith("Expected error for property {0} to contain {1}.", propertyName, partialErrorMessage);

            return new AndConstraint<ValidationErrorDictionaryAssertions>(this);
        }



        // TODO: Unit test this.
        public AndConstraint<ValidationErrorDictionaryAssertions> ContainNotEmptyErrorForProperty(string propertyName)
        {
            return ContainPartialErrorForProperty(propertyName, ValidationMessageFragments.NotEmpty);
        }
    }
}
