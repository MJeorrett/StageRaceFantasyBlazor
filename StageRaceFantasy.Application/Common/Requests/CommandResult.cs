using FluentValidation.Results;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.Common.Requests
{
    public record CommandResult<T>
    {
        public T Content { get; init; }
        public bool IsBadRequest { get; init; }
        public bool IsNotFound { get; init; }
        public IEnumerable<ValidationFailure> ValidationFailures { get; init; }

        public CommandResult()
        {
            ValidationFailures = new List<ValidationFailure>();
        }

        public CommandResult(T content) : this()
        {
            Content = content;
        }

        public CommandResult(IEnumerable<ValidationFailure> validationFailures)
        {
            IsBadRequest = true;
            ValidationFailures = validationFailures;
        }
    }

    public record CommandResult
    {
        public bool IsBadRequest { get; init; }
        public bool IsNotFound { get; init; }
        public IEnumerable<ValidationFailure> ValidationFailures { get; init; }

        public CommandResult()
        {
            ValidationFailures = new List<ValidationFailure>();
        }

        public CommandResult(IEnumerable<ValidationFailure> validationFailures)
        {
            IsBadRequest = true;
            ValidationFailures = validationFailures;
        }

        public static CommandResult<T> Success<T>(T content)
        {
            return new CommandResult<T>(content);
        }

        public static CommandResult Success()
        {
            return new CommandResult();
        }

        public static CommandResult<T> BadRequest<T>(IEnumerable<ValidationFailure> validationFailures)
        {
            return new CommandResult<T>()
            {
                IsBadRequest = true,
                ValidationFailures = validationFailures,
            };
        }

        public static CommandResult<T> BadRequest<T>()
        {
            return new CommandResult<T>()
            {
                IsBadRequest = true,
            };
        }

        public static CommandResult BadRequest()
        {
            return new CommandResult()
            {
                IsBadRequest = true,
            };
        }

        public static CommandResult<T> NotFound<T>()
        {
            return new CommandResult<T>()
            {
                IsNotFound = true,
            };
        }

        public static CommandResult NotFound()
        {
            return new CommandResult()
            {
                IsNotFound = true,
            };
        }
    }
}
