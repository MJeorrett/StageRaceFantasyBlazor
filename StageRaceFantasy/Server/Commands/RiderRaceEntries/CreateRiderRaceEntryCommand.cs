using MediatR;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Commands.RiderRaceEntries
{
    public record CreateRiderRaceEntryCommand(
        int RaceId,
        int RiderId,
        int BibNumber) :
        IRequest<CommandResult<GetRiderRaceEntryDto>>
    {
    }
}
