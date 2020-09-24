using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Queries
{
    public class GetAllFantasyTeamsHandler : IApplicationQueryHandler<GetAllFantasyTeamsQuery, List<FantasyTeam>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllFantasyTeamsHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QueryResult<List<FantasyTeam>>> Handle(GetAllFantasyTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _dbContext.FantasyTeams.ToListAsync();

            return new(teams);
        }
    }
}
