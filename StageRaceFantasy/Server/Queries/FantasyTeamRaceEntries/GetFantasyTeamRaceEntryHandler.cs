using AutoMapper;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Queries.FantasyTeamRaceEntries
{
    public class GetFantasyTeamRaceEntryHandler : IApplicationQueryHandler<GetFantasyTeamRaceEntryQuery, GetFantasyTeamRaceEntryDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFantasyTeamRaceEntryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetFantasyTeamRaceEntryDto>> Handle(GetFantasyTeamRaceEntryQuery request, CancellationToken cancellationToken)
        {
            var teamId = request.FantasyTeamId;
            var raceId = request.RaceId;

            var entry = await _dbContext.FantasyTeamRaceEntries.FindAsync(teamId, raceId);

            if (entry == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            return new(_mapper.Map<GetFantasyTeamRaceEntryDto>(entry));
        }
    }
}
