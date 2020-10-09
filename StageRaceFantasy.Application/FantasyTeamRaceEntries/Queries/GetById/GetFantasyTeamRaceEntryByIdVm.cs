using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetById
{
    public class GetFantasyTeamRaceEntryByIdVm : IMapFrom<FantasyTeamRaceEntry>
    {
        public int FantasyTeamId { get; set; }
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int FantasyTeamSize { get; set; }
        public List<RiderDto> Riders { get; set; }
    }

    public class RiderDto : IMapFrom<Rider>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
