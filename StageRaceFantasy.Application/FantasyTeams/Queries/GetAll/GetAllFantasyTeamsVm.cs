using AutoMapper;
using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetAll
{
    public class GetAllFantasyTeamsVm : IMapFrom<List<FantasyTeam>>
    {
        public List<FantasyTeamDto> FantasyTeams { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<List<FantasyTeam>, GetAllFantasyTeamsVm>()
                .ForMember(dest => dest.FantasyTeams, opts => opts.MapFrom(source => source));
        }
    }

    public class FantasyTeamDto : IMapFrom<FantasyTeam>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
