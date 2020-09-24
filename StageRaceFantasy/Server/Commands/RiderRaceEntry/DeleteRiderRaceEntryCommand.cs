using MediatR;

namespace StageRaceFantasy.Server.Commands.RiderRaceEntry
{
    public record DeleteRiderRaceEntryCommand(
        int RaceId,
        int RiderId)
        : IRequest<CommandResult>
    {
    }
}
