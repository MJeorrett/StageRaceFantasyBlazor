using StageRaceFantasy.Application.Common.Mediatr;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Queries
{
    public record GetFantasyTeamQuery(int TeamId) : IApplicationQuery<GetFantasyTeamDto>
    {
    }
}
