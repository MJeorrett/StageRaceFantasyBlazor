using MediatR;

namespace StageRaceFantasy.Application.Commands
{
    public interface IApplicationCommand<T> : IRequest<CommandResult<T>>
    {
    }

    public interface IApplicationCommand : IRequest<CommandResult>
    {
    }
}
