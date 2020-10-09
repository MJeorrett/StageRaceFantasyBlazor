using StageRaceFantasy.Application.Common.Requests;

namespace StageRaceFantasy.Application.Commands
{
    public record UpdateFantasyTeamCommand(int Id, string Name) : IApplicationCommand
    {
    }
}
