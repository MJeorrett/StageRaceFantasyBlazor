using MediatR;

namespace StageRaceFantasy.Application.Common.Requests
{
    interface IApplicationQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, QueryResult<TResponse>>
        where TRequest : IRequest<QueryResult<TResponse>>
    {
    }
}
