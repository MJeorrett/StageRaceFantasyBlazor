using AutoMapper;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Queries.RaceStages
{
    public class GetRaceStageHandler : IApplicationQueryHandler<GetRaceStageQuery, GetRaceStageDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRaceStageHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetRaceStageDto>> Handle(GetRaceStageQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var stageId = request.StageId;

            var stage = await _dbContext.RaceStages.FindAsync(stageId);

            if (stage.RaceId != raceId)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            return new(_mapper.Map<GetRaceStageDto>(stage));
        }
    }
}
