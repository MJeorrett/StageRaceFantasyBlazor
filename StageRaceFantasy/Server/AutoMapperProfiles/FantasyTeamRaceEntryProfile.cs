using AutoMapper;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.AutoMapperProfiles
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
