using AutoMapper;
using StageRaceFantasy.Application.RaceStages.Queries.GetById;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.AutoMapperProfiles
{
    public class RaceStageProfile : Profile
    {
        public RaceStageProfile()
        {
            CreateMap<RaceStage, GetRaceStageByIdVm>();
        }
    }
}
