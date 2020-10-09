using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetAll
{
    public class GetAllFantasyTeamsVm
    {
        public List<FantasyTeamDto> FantasyTeams { get; set; }
    }

    public class FantasyTeamDto : IMapFrom<FantasyTeam>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
