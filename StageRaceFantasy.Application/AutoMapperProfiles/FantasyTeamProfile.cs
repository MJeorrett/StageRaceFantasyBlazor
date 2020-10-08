using AutoMapper;
using StageRaceFantasy.Application.FantasyTeams.Queries.GetAll;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.AutoMapperProfiles
{
    public class FantasyTeamProfile : Profile
    {
        public FantasyTeamProfile()
        {
            CreateMap<FantasyTeamRaceEntry, GetFantasyTeamDto.RaceEntry>();
            CreateMap<FantasyTeam, GetFantasyTeamDto>();

            CreateMap<FantasyTeam, FantasyTeamDto>();
        }
    }
}
