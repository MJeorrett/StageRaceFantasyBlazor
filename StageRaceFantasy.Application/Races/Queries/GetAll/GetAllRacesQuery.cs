using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Races.Queries.GetAll
{
    public record GetAllRacesQuery : IApplicationRequest<GetAllRacesVm>
    {
    }

    public class GetAllRacesQueryHandler : ApplicationRequestHandler<GetAllRacesQuery, GetAllRacesVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRacesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllRacesVm>> Handle(GetAllRacesQuery request, CancellationToken cancellationToken)
        {
            var races = await _dbContext.Races
                .ProjectTo<RaceDto>(_mapper.ConfigurationProvider)
                .OrderBy(r => r.Name)
                .ToListAsync();

            return Success(new GetAllRacesVm(races));
        }
    }
}
