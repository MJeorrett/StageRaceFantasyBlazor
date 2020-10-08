using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Common.Mediatr
{
    public abstract class ApplicationCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, CommandResult<TResponse>>
        where TRequest : IRequest<CommandResult<TResponse>>
    {
        public abstract Task<CommandResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);

        protected CommandResult<TResponse> Success(TResponse response)
        {
            return CommandResult.Success(response);
        }

        protected CommandResult<TResponse> BadRequest()
        {
            return CommandResult.BadRequest<TResponse>();
        }

        protected CommandResult<TResponse> NotFound()
        {
            return CommandResult.NotFound<TResponse>();
        }
    }

    public abstract class ApplicationCommandHandler<TRequest> : IRequestHandler<TRequest, CommandResult>
        where TRequest : IRequest<CommandResult>
    {
        public abstract Task<CommandResult> Handle(TRequest request, CancellationToken cancellationToken);

        protected CommandResult Success()
        {
            return CommandResult.Success();
        }

        protected CommandResult BadRequest()
        {
            return CommandResult.BadRequest();
        }

        protected CommandResult NotFound()
        {
            return CommandResult.NotFound();
        }
    }
}
