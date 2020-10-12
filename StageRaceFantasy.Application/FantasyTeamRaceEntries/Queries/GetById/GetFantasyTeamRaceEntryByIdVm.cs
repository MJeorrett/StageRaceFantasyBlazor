using AutoMapper;
using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetById
{
    public class GetFantasyTeamRaceEntryByIdVm : IMapFrom
    {
        public int FantasyTeamId { get; set; }
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int FantasyTeamSize { get; set; }
        public List<RiderDto> Riders { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FantasyTeamRaceEntry, GetFantasyTeamRaceEntryByIdVm>()
                .ForMember(dest => dest.FantasyTeamSize, opt => opt.MapFrom(src => src.Race.FantasyTeamSize));
        }
    }

    public class RiderDto : IMapFrom<Rider>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
