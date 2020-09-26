﻿using System.Collections.Generic;

namespace StageRaceFantasy.Shared.Models
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
        public int RaceName { get; set; }
        public List<Rider> Riders { get; set; }
    }
}
