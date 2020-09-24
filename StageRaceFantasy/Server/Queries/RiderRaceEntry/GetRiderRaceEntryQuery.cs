using MediatR;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Queries.RiderRaceEntry
{
    public record GetRiderRaceEntryQuery(int raceId, int riderId) : IRequest<QueryResult<GetRiderRaceEntryDto>>
    {
    }
}
