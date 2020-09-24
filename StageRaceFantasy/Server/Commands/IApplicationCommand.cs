using MediatR;

namespace StageRaceFantasy.Server.Commands
{
    public interface IApplicationCommand<T> : IRequest<CommandResult<T>>
    {
    }

    public interface IApplicationCommand : IRequest<CommandResult>
    {
    }
}
