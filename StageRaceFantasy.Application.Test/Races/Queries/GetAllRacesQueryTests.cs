using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Races.Queries.GetAll;
using StageRaceFantasy.Domain.Entities;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.IntegrationTests.Races.Queries
{
    using static Testing;

    public class GetAllRacesQueryTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllRaces()
        {
            var race1Id = await AddAsync(new Race() { Name = "Tour de France 2019" });
            var race2Id = await AddAsync(new Race() { Name = "Tour de France 2020" });

            var result = await SendAsync(new GetAllRacesQuery());

            result.Content.Races.Should().HaveCount(2);
            result.Content.Races[0].Id.Should().Be(race1Id);
            result.Content.Races[0].Name.Should().Be("Tour de France 2019");
            result.Content.Races[1].Id.Should().Be(race2Id);
            result.Content.Races[1].Name.Should().Be("Tour de France 2020");
        }
    }
}
