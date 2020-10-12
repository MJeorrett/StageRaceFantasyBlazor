using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Riders.Queries.GetById
{
    public record GetRiderByIdVm : IMapFrom<Rider>
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}
