using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Queries.FantasyTeamRaceEntries
{
    public class GetFantasyTeamRaceEntryHandler : IApplicationQueryHandler<GetFantasyTeamRaceEntryQuery, GetFantasyTeamRaceEntryDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFantasyTeamRaceEntryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetFantasyTeamRaceEntryDto>> Handle(GetFantasyTeamRaceEntryQuery request, CancellationToken cancellationToken)
        {
            var teamId = request.FantasyTeamId;
            var raceId = request.RaceId;

            var entry = await _dbContext.FantasyTeamRaceEntries
                .Include(x => x.FantasyTeamRaceEntryRiders)
                    .ThenInclude(x => x.Rider)
                .Include(x => x.Race)
                .FirstOrDefaultAsync(x => x.FantasyTeamId == teamId && x.RaceId == raceId);

            if (entry == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var result = _mapper.Map<GetFantasyTeamRaceEntryDto>(entry);
            
            var race = await _dbContext.Races.FindAsync(raceId);
            result.FantasyTeamSize = race.FantasyTeamSize;

            return new(result);
        }
    }
}
