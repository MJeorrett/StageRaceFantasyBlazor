using MediatR;

namespace StageRaceFantasy.Application.Common.Requests
{
    public interface IApplicationCommand<T> : IRequest<CommandResult<T>>, IApplicationRequest
    {
    }

    public interface IApplicationCommand : IRequest<CommandResult>, IApplicationRequest
    {
    }
}
