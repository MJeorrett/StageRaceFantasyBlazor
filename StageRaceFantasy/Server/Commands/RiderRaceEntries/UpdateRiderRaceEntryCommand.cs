using MediatR;

namespace StageRaceFantasy.Server.Commands.RiderRaceEntries
{
    public record UpdateRiderRaceEntryCommand(int RaceId, int RiderId, int BibNumber)
        : IRequest<CommandResult>
    {
    }
}
