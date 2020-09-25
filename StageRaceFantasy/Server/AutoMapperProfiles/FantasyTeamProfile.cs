using AutoMapper;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.AutoMapperProfiles
{
    public class FantasyTeamProfile : Profile
    {
        public FantasyTeamProfile()
        {
            CreateMap<FantasyTeamRaceEntry, GetFantasyTeamDto.RaceEntry>();
            CreateMap<FantasyTeam, GetFantasyTeamDto>();

            CreateMap<FantasyTeam, GetAllFantasyTeamsDto>();
        }
    }
}
