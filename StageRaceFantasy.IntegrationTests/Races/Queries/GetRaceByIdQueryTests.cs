using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Races.Queries.GetById;
using StageRaceFantasy.Domain.Entities;
using System.Threading.Tasks;

namespace StageRaceFantasy.IntegrationTests.Races.Queries
{
    using static Testing;

    public class GetRaceByIdQueryTests : TestBase
    {
        [Test]
        public async Task ShouldReturnNotFound()
        {
            var result = await SendAsync(new GetRaceByIdQuery(123));

            result.IsNotFound.Should().BeTrue();
        }
        
        [Test]
        public async Task ShouldReturnRace()
        {
            var raceId = await AddAsync(new Race()
            {
                Name = "La Tour 2015",
            });

            var result = await SendAsync(new GetRaceByIdQuery(raceId));

            result.Should().NotBeNull();
            result.Content.Id.Should().Be(raceId);
            result.Content.Name.Should().Be("La Tour 2015");
        }
    }
}
