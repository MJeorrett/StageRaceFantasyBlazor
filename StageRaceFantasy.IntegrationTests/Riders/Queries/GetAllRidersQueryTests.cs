using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Riders.Queries.GetAll;
using StageRaceFantasy.Domain.Entities;
using System.Threading.Tasks;

namespace StageRaceFantasy.IntegrationTests.Riders.Queries
{
    using static Testing;

    public class GetAllRidersQueryTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllRiders()
        {
            await AddAsync(new Rider() { FirstName = "Wout", LastName = "Van Aert" });
            await AddAsync(new Rider() { FirstName = "Simon", LastName = "Yates" });
            await AddAsync(new Rider() { FirstName = "Tony", LastName = "Martin" });

            var result = await SendAsync(new GetAllRidersQuery());

            result.Content.Should().NotBeNull();
            result.Content.Riders.Should().HaveCount(3);
        }
    }
}
