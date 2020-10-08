using StageRaceFantasy.Application.Common.Mediatr;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Commands
{
    public record CreateFantasyTeamCommand(string Name) : IApplicationCommand<FantasyTeam>
    {
    }
}
