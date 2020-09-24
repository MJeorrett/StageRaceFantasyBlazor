using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Queries
{
    public class GetFantasyTeamHandler : IApplicationQueryHandler<GetFantasyTeamQuery, FantasyTeam>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetFantasyTeamHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QueryResult<FantasyTeam>> Handle(GetFantasyTeamQuery request, CancellationToken cancellationToken)
        {
            var teamId = request.TeamId;

            var fantasyTeam = await _dbContext.FantasyTeams.FindAsync(teamId);

            if (fantasyTeam == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            return new(fantasyTeam);
        }
    }
}
