using StageRaceFantasy.Application.Common.Mediatr;

namespace StageRaceFantasy.Application.Commands
{
    public record DeleteFantasyTeamCommand(int Id) : IApplicationCommand
    {
    }
}
