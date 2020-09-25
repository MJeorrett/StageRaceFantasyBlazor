using System.Collections.Generic;

namespace StageRaceFantasy.Shared.Models
{
    public class FantasyTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FantasyTeamRaceEntry> RaceEntries { get; set; }
    }
}
