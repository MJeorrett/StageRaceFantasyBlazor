using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Queries
{
    public class GetAllFantasyTeamsHandler : IApplicationQueryHandler<GetAllFantasyTeamsQuery, List<GetAllFantasyTeamsDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFantasyTeamsHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<List<GetAllFantasyTeamsDto>>> Handle(GetAllFantasyTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _dbContext.FantasyTeams.ToListAsync();

            return new(_mapper.Map<List<GetAllFantasyTeamsDto>>(teams));
        }
    }
}
