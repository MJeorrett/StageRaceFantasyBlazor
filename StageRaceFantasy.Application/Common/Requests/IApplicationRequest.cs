using MediatR;

namespace StageRaceFantasy.Application.Common.Requests
{
    public interface IApplicationRequest<T> : IRequest<ApplicationRequestResult<T>>
    {
    }

    public interface IApplicationRequest : IRequest<ApplicationRequestResult>
    {
    }
}
