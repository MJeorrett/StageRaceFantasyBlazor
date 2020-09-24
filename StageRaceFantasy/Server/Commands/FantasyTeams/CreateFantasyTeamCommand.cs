using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Commands
{
    public record CreateFantasyTeamCommand(string Name) : IApplicationCommand<FantasyTeam>
    {
    }
}
