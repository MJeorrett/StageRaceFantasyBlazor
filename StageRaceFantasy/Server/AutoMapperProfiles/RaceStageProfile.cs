using AutoMapper;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.AutoMapperProfiles
{
    public class RaceStageProfile : Profile
    {
        public RaceStageProfile()
        {
            CreateMap<RaceStage, GetRaceStageDto>();
        }
    }
}
