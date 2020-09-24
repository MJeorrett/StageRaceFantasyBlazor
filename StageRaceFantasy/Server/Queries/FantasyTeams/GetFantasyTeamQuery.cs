using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Queries
{
    public record GetFantasyTeamQuery(int TeamId) : IApplicationQuery<FantasyTeam>
    {
    }
}
