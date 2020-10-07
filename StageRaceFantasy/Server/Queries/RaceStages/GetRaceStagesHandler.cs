using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Queries.GetRaceStages
{
    public class GetRaceStagesHandler : IApplicationQueryHandler<GetRaceStagesQuery, List<GetRaceStageDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRaceStagesHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<List<GetRaceStageDto>>> Handle(GetRaceStagesQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;

            var raceExists = await _dbContext.Races.AnyAsync(r => r.Id == raceId);

            if (!raceExists)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var stages = await _dbContext.RaceStages
                .Where(s => s.RaceId == raceId)
                .ToListAsync();

            return new(_mapper.Map<List<GetRaceStageDto>>(stages));
        }
    }
}
