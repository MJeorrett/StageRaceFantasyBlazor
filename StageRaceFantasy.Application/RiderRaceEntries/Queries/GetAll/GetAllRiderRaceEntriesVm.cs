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
            profile.CreateMap<RiderRaceEntry, RiderRaceEntryDto>();

            profile.CreateMap<Rider, RiderRaceEntryDto>()
                .ForMember(dest => dest.RiderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RiderFirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.RiderLastName, opt => opt.MapFrom(src => src.LastName));
        }
    }
}
