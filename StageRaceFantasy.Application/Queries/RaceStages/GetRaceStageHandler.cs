using AutoMapper;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Queries.RaceStages
{
    public class GetRaceStageHandler : IApplicationQueryHandler<GetRaceStageQuery, GetRaceStageDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRaceStageHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationRequestResult<GetRaceStageDto>> Handle(GetRaceStageQuery request, CancellationToken cancellationToken)
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
