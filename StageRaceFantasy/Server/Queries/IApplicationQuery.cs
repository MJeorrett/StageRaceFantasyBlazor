using MediatR;

namespace StageRaceFantasy.Server.Queries
{
    public interface IApplicationQuery<T> : IRequest<QueryResult<T>>
    {
    }
}
