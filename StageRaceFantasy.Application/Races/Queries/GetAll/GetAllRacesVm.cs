using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.Races.Queries.GetAll
{
    public record GetAllRacesVm(List<RaceDto> Races) { }

    public record RaceDto : IMapFrom<Race>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int FantasyTeamSize { get; init; }
    }
}
