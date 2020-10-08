using MediatR;

namespace StageRaceFantasy.Application.Common.Mediatr
{
    interface IApplicationQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, QueryResult<TResponse>>
        where TRequest : IRequest<QueryResult<TResponse>>
    {
    }
}
