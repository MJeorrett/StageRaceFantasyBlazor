using AutoMapper;
using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.RiderRaceEntries.Queries.GetAll
{
    public class GetAllRiderRaceEntriesVm
    {
        public List<RiderRaceEntryDto> Entries { get; set; }
    }

    public class RiderRaceEntryDto : IMapFrom
    {
        public int RaceId { get; set; }
        public int RiderId { get; set; }
        public string RiderFirstName { get; set; }
        public string RiderLastName { get; set; }
        public bool IsEntered { get; set; }
        public int BibNumber { get; set; }
        public int StarValue { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RiderRaceEntry, RiderRaceEntryDto>()
                .ForMember(dest => dest.IsEntered, opt => opt.Ignore());
        }
    }
}
