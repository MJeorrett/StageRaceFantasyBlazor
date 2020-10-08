using MediatR;

namespace StageRaceFantasy.Application.Common.Mediatr
{
    public interface IApplicationQuery<T> : IRequest<QueryResult<T>>
    {
    }
}
