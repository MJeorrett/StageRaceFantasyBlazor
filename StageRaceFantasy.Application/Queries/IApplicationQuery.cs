using MediatR;

namespace StageRaceFantasy.Application.Queries
{
    public interface IApplicationQuery<T> : IRequest<QueryResult<T>>
    {
    }
}
