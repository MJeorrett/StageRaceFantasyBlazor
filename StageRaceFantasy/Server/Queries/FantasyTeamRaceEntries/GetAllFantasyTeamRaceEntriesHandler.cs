using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Queries.FantasyTeamRaceEntries
{
    public class GetAllFantasyTeamRaceEntriesHandler : IApplicationQueryHandler<GetAllFantasyTeamRaceEntriesQuery, List<GetFantasyTeamRaceEntryDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFantasyTeamRaceEntriesHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<List<GetFantasyTeamRaceEntryDto>>> Handle(GetAllFantasyTeamRaceEntriesQuery request, CancellationToken cancellationToken)
        {
            var teamId = request.TeamId;

            var teamExists = await _dbContext.FantasyTeams.AnyAsync(x => x.Id == teamId);

            if (!teamExists)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var raceEntries = await _dbContext.FantasyTeamRaceEntries
                .Include(x => x.FantasyTeamRaceEntryRiders)
                .Where(x => x.FantasyTeamId == teamId)
                .OrderBy(x => x.Race.Name)
                .ToListAsync();

            return new(_mapper.Map<List<GetFantasyTeamRaceEntryDto>>(raceEntries));
        }
    }
}
