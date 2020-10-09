﻿using AutoMapper;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RaceStages.Commands.Create
{
    public record CreateRaceStageCommand : IApplicationCommand<GetRaceStageDto>
    {
        public int RaceId { get; init; }
        public string StartLocation { get; init; }
        public string FinishLocation { get; init; }
    }

    public class CreateRaceStageHandler : ApplicationCommandHandler<CreateRaceStageCommand, GetRaceStageDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateRaceStageHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetRaceStageDto>> Handle(CreateRaceStageCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;

            var race = await _dbContext.Races.FindAsync(new object[] { raceId }, cancellationToken: cancellationToken);

            if (race == null) return NotFound();

            var raceStage = new RaceStage()
            {
                Race = race,
                StartLocation = request.StartLocation,
                FinishLocation = request.FinishLocation,
            };

            await _dbContext.RaceStages.AddAsync(raceStage);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(_mapper.Map<GetRaceStageDto>(raceStage));
        }
    }
}