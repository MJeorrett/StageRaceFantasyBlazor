using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Queries.GetRaceStages
{
    public class GetRaceStagesHandler : IApplicationQueryHandler<GetRaceStagesQuery, GetRaceStagesDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRaceStagesHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetRaceStagesDto>> Handle(GetRaceStagesQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;

            var race = await _dbContext.Races
                .Include(x => x.Stages)
                .FirstOrDefaultAsync(x => x.Id == raceId);

            if (race == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            return new(_mapper.Map<GetRaceStagesDto>(race));
        }
    }
}
