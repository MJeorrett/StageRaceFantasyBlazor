using MediatR;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Queries.RiderRaceEntries
{
    public record GetRiderRaceEntryQuery(int raceId, int riderId) : IRequest<QueryResult<GetRiderRaceEntryDto>>
    {
    }
}
