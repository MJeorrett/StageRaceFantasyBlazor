using AutoMapper;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.AutoMapperProfiles
{
    public class FantasyTeamRaceEntryProfile : Profile
    {
        public FantasyTeamRaceEntryProfile()
        {
            CreateMap<FantasyTeamRaceEntry, GetAllFantasyTeamRaceEntriesDto>();

            CreateMap<Rider, GetFantasyTeamRaceEntryDto.Rider>();
            CreateMap<FantasyTeamRaceEntry, GetFantasyTeamRaceEntryDto>();
        }
    }
}
