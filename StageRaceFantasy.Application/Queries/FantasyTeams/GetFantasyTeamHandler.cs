using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Queries
{
    public class GetFantasyTeamHandler : IApplicationQueryHandler<GetFantasyTeamQuery, GetFantasyTeamDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFantasyTeamHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetFantasyTeamDto>> Handle(GetFantasyTeamQuery request, CancellationToken cancellationToken)
        {
            var teamId = request.TeamId;

            var fantasyTeam = await _dbContext.FantasyTeams
                .Include(x => x.RaceEntries)
                    .ThenInclude(x => x.Race)
                .FirstOrDefaultAsync(x => x.Id == teamId);

            if (fantasyTeam == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            return new(_mapper.Map<GetFantasyTeamDto>(fantasyTeam));
        }
    }
}
