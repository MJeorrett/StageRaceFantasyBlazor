using MediatR;

namespace StageRaceFantasy.Server.Commands
{
    public record DeleteRiderRaceEntryCommand(
        int RaceId,
        int RiderId)
        : IRequest<CommandResult>
    {
    }
}
