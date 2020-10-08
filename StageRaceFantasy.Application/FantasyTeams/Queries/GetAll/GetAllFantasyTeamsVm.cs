using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetAll
{
    public class GetAllFantasyTeamsVm
    {
        public List<FantasyTeamDto> FantasyTeams { get; set; }
    }

    public class FantasyTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
