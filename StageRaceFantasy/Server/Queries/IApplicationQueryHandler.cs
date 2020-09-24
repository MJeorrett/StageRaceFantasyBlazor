using MediatR;

namespace StageRaceFantasy.Server.Queries
{
    interface IApplicationQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, QueryResult<TResponse>>
        where TRequest : IRequest<QueryResult<TResponse>>
    {
    }
}
