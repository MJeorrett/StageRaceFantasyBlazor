using FluentAssertions;
using NUnit.Framework;
using StageRaceFantasy.Application.Riders.Commands.Delete;
using StageRaceFantasy.Domain.Entities;
using System.Threading.Tasks;

namespace StageRaceFantasy.IntegrationTests.Riders.Commands
{
    using static Testing;

    public class DeleteRiderCommandTests : TestBase
    {
        [Test]
        public async Task ShouldReturnNotFound()
        {
            var command = new DeleteRiderCommand(299);

            var result = await SendAsync(command);

            result.IsNotFound.Should().BeTrue();
        }

        [Test]
        public async Task ShouldDeleteRider()
        {
            var riderId = await AddAsync(new Rider()
            {
                FirstName = "Marcel",
                LastName = "Kittel",
            });

            await SendAsync(new DeleteRiderCommand(riderId));

            var rider = await FindAsync<Rider>(riderId);

            rider.Should().BeNull();
        }
    }
}
