using AutoMapper;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.AutoMapperProfiles
{
    public class RaceStageProfile : Profile
    {
        public RaceStageProfile()
        {
            CreateMap<RaceStage, GetRaceStageDto>();
        }
    }
}
