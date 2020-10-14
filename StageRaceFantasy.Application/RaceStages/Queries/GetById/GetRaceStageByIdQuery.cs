using AutoMapper;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RaceStages.Queries.GetById
{
    public record GetRaceStageByIdQuery(int RaceId, int StageId)
        : IApplicationRequest<GetRaceStageByIdVm>
    {
    }

    public class GetRaceStageByIdHandler : ApplicationRequestHandler<GetRaceStageByIdQuery, GetRaceStageByIdVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRaceStageByIdHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetRaceStageByIdVm>> Handle(GetRaceStageByIdQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var stageId = request.StageId;

            var stage = await _dbContext.RaceStages.FindAsync(new object[] { stageId }, cancellationToken: cancellationToken);

            if (stage.RaceId != raceId) return NotFound();

            return Success(_mapper.Map<GetRaceStageByIdVm>(stage));
        }
    }
}
