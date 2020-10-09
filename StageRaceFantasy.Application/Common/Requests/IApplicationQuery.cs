using MediatR;

namespace StageRaceFantasy.Application.Common.Requests
{
    public interface IApplicationQuery<T> : IRequest<QueryResult<T>>, IApplicationRequest
    {
    }
}
