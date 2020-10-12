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
            await AddAsync(new Race() { Name = "B race" });
            await AddAsync(new Race() { Name = "C race" });
            await AddAsync(new Race() { Name = "A race" });

            var result = await SendAsync(new GetAllRacesQuery());

            result.Content.Races.Should().HaveCount(3);
        }
    }
}
