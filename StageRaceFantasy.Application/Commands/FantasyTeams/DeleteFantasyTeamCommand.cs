using StageRaceFantasy.Application.Common.Requests;

namespace StageRaceFantasy.Application.Commands
{
    public record DeleteFantasyTeamCommand(int Id) : IApplicationCommand
    {
    }
}
