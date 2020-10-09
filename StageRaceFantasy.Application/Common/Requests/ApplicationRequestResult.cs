using FluentValidation.Results;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.Common.Requests
{
    public record ApplicationRequestResult<T>
    {
        public T Content { get; init; }
        public bool IsBadRequest { get; init; }
        public bool IsNotFound { get; init; }
        public IEnumerable<ValidationFailure> ValidationFailures { get; init; }

        public ApplicationRequestResult()
        {
            ValidationFailures = new List<ValidationFailure>();
        }

        public ApplicationRequestResult(T content) : this()
        {
            Content = content;
        }

        // This constructor is required by ValidationBehaviour which uses reflection.
        public ApplicationRequestResult(IEnumerable<ValidationFailure> validationFailures)
        {
            IsBadRequest = true;
            ValidationFailures = validationFailures;
        }
    }



    public record ApplicationRequestResult
    {
        public bool IsBadRequest { get; init; }
        public bool IsNotFound { get; init; }
        public IEnumerable<ValidationFailure> ValidationFailures { get; init; }

        public ApplicationRequestResult()
        {
            ValidationFailures = new List<ValidationFailure>();
        }

        // This constructor is required by ValidationBehaviour which uses reflection.
        public ApplicationRequestResult(IEnumerable<ValidationFailure> validationFailures)
        {
            IsBadRequest = true;
            ValidationFailures = validationFailures;
        }

        public static ApplicationRequestResult<T> Success<T>(T content)
        {
            return new ApplicationRequestResult<T>(content);
        }

        public static ApplicationRequestResult Success()
        {
            return new ApplicationRequestResult();
        }

        public static ApplicationRequestResult<T> BadRequest<T>(IEnumerable<ValidationFailure> validationFailures)
        {
            return new ApplicationRequestResult<T>()
            {
                IsBadRequest = true,
                ValidationFailures = validationFailures,
            };
        }

        public static ApplicationRequestResult<T> BadRequest<T>()
        {
            return new ApplicationRequestResult<T>()
            {
                IsBadRequest = true,
            };
        }

        public static ApplicationRequestResult BadRequest()
        {
            return new ApplicationRequestResult()
            {
                IsBadRequest = true,
            };
        }

        public static ApplicationRequestResult<T> NotFound<T>()
        {
            return new ApplicationRequestResult<T>()
            {
                IsNotFound = true,
            };
        }

        public static ApplicationRequestResult NotFound()
        {
            return new ApplicationRequestResult()
            {
                IsNotFound = true,
            };
        }
    }
}
