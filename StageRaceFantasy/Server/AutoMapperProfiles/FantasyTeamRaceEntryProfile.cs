using AutoMapper;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.AutoMapperProfiles
{
    public class FantasyTeamRaceEntryProfile : Profile
    {
        public FantasyTeamRaceEntryProfile()
        {
            CreateMap<FantasyTeamRaceEntry, GetFantasyTeamRaceEntryDto>()
                .ForMember(dest => dest.RiderIds, opt => opt.MapFrom(ftre => ftre.RiderIds));
        }
    }
}
