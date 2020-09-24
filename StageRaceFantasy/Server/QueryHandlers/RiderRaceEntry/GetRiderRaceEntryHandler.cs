using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Server.Queries;
using StageRaceFantasy.Server.Queries.RiderRaceEntry;
using StageRaceFantasy.Shared.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.QueryHandlers.RiderRaceEntry
{
    public class GetRiderRaceEntryHandler : IRequestHandler<GetRiderRaceEntryQuery, QueryResult<GetRiderRaceEntryDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRiderRaceEntryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetRiderRaceEntryDto>> Handle(GetRiderRaceEntryQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.raceId;
            var riderId = request.riderId;

            var riderRaceEntry = await _dbContext.RiderRaceEntries
                .Include(x => x.Race)
                .Include(x => x.Rider)
                .Where(x => x.RaceId == raceId && x.RiderId == riderId)
                .FirstOrDefaultAsync();

            if (riderRaceEntry != null)
            {
                var riderRaceEntryDto = _mapper.Map<GetRiderRaceEntryDto>(riderRaceEntry);
                riderRaceEntryDto.IsEntered = true;

                return new(riderRaceEntryDto);
            }

            var race = await _dbContext.Races.FindAsync(raceId);
            var rider = await _dbContext.Riders.FindAsync(riderId);

            if (race == null || rider == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            // TODO: This should be handled int automapper.
            return new(new GetRiderRaceEntryDto
            {
                RaceId = raceId,
                RiderId = rider.Id,
                RiderFirstName = rider.FirstName,
                RiderLastName = rider.LastName,
            });
        }
    }
}
