using MediatR;

namespace StageRaceFantasy.Application.Common.Mediatr
{
    public interface IApplicationCommand<T> : IRequest<CommandResult<T>>
    {
    }

    public interface IApplicationCommand : IRequest<CommandResult>
    {
    }
}
