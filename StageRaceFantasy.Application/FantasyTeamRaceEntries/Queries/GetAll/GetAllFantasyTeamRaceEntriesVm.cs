using StageRaceFantasy.Application.Common.AutoMapper;
using System.Collections.Generic;

namespace StageRaceFantasy.Domain.Entities
{
    public class GetAllFantasyTeamRaceEntriesVm
    {
        public List<FantasyTeamRaceEntryDto> Entries { get; set; }
    }

    public class FantasyTeamRaceEntryDto : IMapFrom<FantasyTeamRaceEntry>
    {
        public int FantasyTeamId { get; set; }
        public int RaceId { get; set; }
        public int RaceName { get; set; }
    }    
}
