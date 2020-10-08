using AutoMapper;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.AutoMapperProfiles
{
    public class FantasyTeamProfile : Profile
    {
        public FantasyTeamProfile()
        {
            CreateMap<FantasyTeamRaceEntry, GetFantasyTeamDto.RaceEntry>();
            CreateMap<FantasyTeam, GetFantasyTeamDto>();
        }
    }
}
