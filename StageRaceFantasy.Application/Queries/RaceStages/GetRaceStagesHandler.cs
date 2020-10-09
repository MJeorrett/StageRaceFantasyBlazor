using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Queries.GetRaceStages
{
    public class GetRaceStagesHandler : IApplicationQueryHandler<GetRaceStagesQuery, List<GetRaceStageDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRaceStagesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationRequestResult<List<GetRaceStageDto>>> Handle(GetRaceStagesQuery request, CancellationToken cancellationToken)
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
