using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RaceStages.Queries.GetAll
{
    public record GetAllRaceStagesQuery(int RaceId)
        : IApplicationRequest<GetAllRaceStagesVm>
    {
    }

    public class GetAllRaceStagesHandler : ApplicationRequestHandler<GetAllRaceStagesQuery, GetAllRaceStagesVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRaceStagesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllRaceStagesVm>> Handle(GetAllRaceStagesQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;

            var raceExists = await _dbContext.Races.AnyAsync(r => r.Id == raceId, cancellationToken);

            if (!raceExists) return NotFound();

            var raceStageDtos = await _dbContext.RaceStages
                .Where(s => s.RaceId == raceId)
                .ProjectTo<RaceStageDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Success(new GetAllRaceStagesVm()
            {
                RaceStages = raceStageDtos,
            });
        }
    }
}
