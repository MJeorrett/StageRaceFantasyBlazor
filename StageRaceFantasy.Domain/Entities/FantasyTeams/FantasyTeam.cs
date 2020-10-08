using System.Collections.Generic;

namespace StageRaceFantasy.Domain.Entities
{
    public class FantasyTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FantasyTeamRaceEntry> RaceEntries { get; set; }
    }
}
