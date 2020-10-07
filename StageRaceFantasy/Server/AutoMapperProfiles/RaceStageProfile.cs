using AutoMapper;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.AutoMapperProfiles
{
    public class RaceStageProfile : Profile
    {
        public RaceStageProfile()
        {
            CreateMap<RaceStage, GetRaceStagesDto.Stage>();
            CreateMap<Race, GetRaceStagesDto>()
                .ForMember(dest => dest.RaceName, opt => opt.MapFrom(r => r.Name));

            CreateMap<RaceStage, GetRaceStageDto>();
        }
    }
}
