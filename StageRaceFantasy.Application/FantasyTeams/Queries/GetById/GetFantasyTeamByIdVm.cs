using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetById
{
    public record GetFantasyTeamByIdVm : IMapFrom<FantasyTeam>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public List<FantasyTeamRaceEntryDto> RaceEntries { get; init; }
    }

    public record FantasyTeamRaceEntryDto : IMapFrom<FantasyTeamRaceEntry>
    {
        public int RaceId { get; init; }
        public string RaceName { get; init; }
    }
}
