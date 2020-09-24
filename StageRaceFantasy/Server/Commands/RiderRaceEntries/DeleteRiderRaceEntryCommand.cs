namespace StageRaceFantasy.Server.Commands
{
    public record DeleteRiderRaceEntryCommand(int RaceId, int RiderId) :
        IApplicationCommand
    {
    }
}
