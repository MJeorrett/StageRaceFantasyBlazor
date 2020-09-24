using MediatR;
using StageRaceFantasy.Shared.Models;
using System.Collections.Generic;

namespace StageRaceFantasy.Server.Queries
{
    public class GetAllRiderRaceEntriesQuery : IRequest<List<GetRiderRaceEntryDto>>
    {
        public int RaceId { get; init; }

        public GetAllRiderRaceEntriesQuery(int raceId)
        {
            RaceId = raceId;
        }
    }
}
