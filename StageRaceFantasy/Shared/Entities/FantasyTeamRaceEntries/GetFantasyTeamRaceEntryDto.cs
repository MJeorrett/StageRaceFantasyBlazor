using System.Collections.Generic;

namespace StageRaceFantasy.Domain.Entities
{
    public class GetFantasyTeamRaceEntryDto
    {
        public class Rider
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public int FantasyTeamId { get; set; }
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int FantasyTeamSize { get; set; }
        public List<Rider> Riders { get; set; }
    }
}
