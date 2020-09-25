﻿using System.Collections.Generic;

namespace StageRaceFantasy.Shared.Models
{
    public class Rider
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<FantasyTeamRaceEntryRider> FantasyTeamRaceEntryRiders { get; set; }
    }
}
