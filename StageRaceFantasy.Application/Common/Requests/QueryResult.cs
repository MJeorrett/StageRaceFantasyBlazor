using FluentValidation.Results;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.Common.Requests
{
    public record QueryResult<T>
    {
        public T Content { get; init; }
        public bool IsBadRequest { get; init; }
        public bool IsNotFound { get; init; }
        public IEnumerable<ValidationFailure> ValidationFailures { get; init; }

        public QueryResult()
        {
            ValidationFailures = new List<ValidationFailure>();
        }

        public QueryResult(T content) : this()
        {
            Content = content;
        }

        public QueryResult(IEnumerable<ValidationFailure> validationFailures)
        {
            IsBadRequest = true;
            ValidationFailures = validationFailures;
        }
    }
}
