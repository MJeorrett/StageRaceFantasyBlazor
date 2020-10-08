using StageRaceFantasy.Application.Common.Mediatr;

namespace StageRaceFantasy.Application.Commands
{
    public record DeleteRiderRaceEntryCommand(int RaceId, int RiderId) :
        IApplicationCommand
    {
    }
}
