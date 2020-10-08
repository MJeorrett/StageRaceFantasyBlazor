namespace StageRaceFantasy.Application.Commands
{
    public record DeleteRiderRaceEntryCommand(int RaceId, int RiderId) :
        IApplicationCommand
    {
    }
}
