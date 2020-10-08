using MediatR;

namespace StageRaceFantasy.Application.Common.Mediatr
{
    interface IApplicationCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, CommandResult<TResponse>>
        where TRequest : IRequest<CommandResult<TResponse>>
    {
    }

    interface IApplicationCommandHandler<TRequest> : IRequestHandler<TRequest, CommandResult>
        where TRequest : IRequest<CommandResult>
    {
    }
}
