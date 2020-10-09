using FluentValidation;
using FluentValidation.Results;
using MediatR;
using StageRaceFantasy.Application.Common.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IApplicationRequest
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {

            if (!_validators.Any()) return await next();

            var failures = await DoValidation(request, cancellationToken);

            if (failures.Any())
            {
                return BuildFailureResponse(failures);
            }

            return await next();
        }

        private async Task<IEnumerable<ValidationFailure>> DoValidation(TRequest request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            return failures;
        }

        private static TResponse BuildFailureResponse(IEnumerable<ValidationFailure> failures)
        {
            var responseType = typeof(TResponse);

            return Activator.CreateInstance(responseType, failures) as TResponse;
        }
    }
}
