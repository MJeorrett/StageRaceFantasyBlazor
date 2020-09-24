namespace StageRaceFantasy.Server.Commands
{
    public record UpdateFantasyTeamCommand(int Id, string Name) : IApplicationCommand
    {
    }
}
