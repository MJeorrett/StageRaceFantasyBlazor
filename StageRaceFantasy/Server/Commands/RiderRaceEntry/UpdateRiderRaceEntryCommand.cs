using MediatR;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Commands.RiderRaceEntry
{
    public record UpdateRiderRaceEntryCommand(
        int RaceId,
        int RiderId,
        UpdateRiderRaceEntryDto UpdateRiderRaceEntryDto
        ) : IRequest<CommandResult>
    {
    }
}
