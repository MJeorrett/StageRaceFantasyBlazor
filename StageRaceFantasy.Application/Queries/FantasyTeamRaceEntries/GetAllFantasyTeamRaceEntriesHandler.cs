using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Queries.FantasyTeamRaceEntries
{
    public class GetAllFantasyTeamRaceEntriesHandler : IApplicationQueryHandler<GetAllFantasyTeamRaceEntriesQuery, List<GetAllFantasyTeamRaceEntriesDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFantasyTeamRaceEntriesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationRequestResult<List<GetAllFantasyTeamRaceEntriesDto>>> Handle(GetAllFantasyTeamRaceEntriesQuery request, CancellationToken cancellationToken)
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
                .Where(x => x.FantasyTeamId == teamId)
                .OrderBy(x => x.Race.Name)
                .ToListAsync();

            return new(_mapper.Map<List<GetAllFantasyTeamRaceEntriesDto>>(raceEntries));
        }
    }
}
