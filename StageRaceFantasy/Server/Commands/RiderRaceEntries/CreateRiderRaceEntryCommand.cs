using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Commands
{
    public record CreateRiderRaceEntryCommand(int RaceId, int RiderId, int BibNumber) :
        IApplicationCommand<GetRiderRaceEntryDto>
    {
    }
}
