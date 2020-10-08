using System.Collections.Generic;

namespace StageRaceFantasy.Domain.Entities
{
    public class GetFantasyTeamDto
    {
        public class RaceEntry
        {
            public int RaceId { get; set; }
            public string RaceName { get; set; }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<RaceEntry> RaceEntries { get; set; }
    }
}
