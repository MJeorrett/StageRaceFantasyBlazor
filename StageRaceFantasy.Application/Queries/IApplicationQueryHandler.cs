using MediatR;

namespace StageRaceFantasy.Application.Queries
{
    interface IApplicationQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, QueryResult<TResponse>>
        where TRequest : IRequest<QueryResult<TResponse>>
    {
    }
}
